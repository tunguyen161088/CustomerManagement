using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using CustomerManagement.Services;
using Data;

namespace CustomerManagement.Orders
{
    public class OrderListViewModel: ViewModelBase
    {
        private readonly ICustomerHelper _customerHelper = new CustomerHelper();
        private readonly IOrderHelper _orderHelper = new OrderHelper();
        public RelayCommand SearchCommand { get; }
        public OrderListViewModel()
        {
            SearchCommand = new RelayCommand(OnSearch);
        }

        public async void LoadCustomers()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;

            _customerDetails = new List<CustomerDetail>();

            var customers = await _customerHelper.GetCustomersAsync();

            customers.ForEach(x=>_customerDetails.Add(new CustomerDetail
            {
                CustomerId = x.CustomerId,
                Name = x.Name
            }));

            _customerDetails.ForEach(async x => x.Orders = new ObservableCollection<Order>(await _orderHelper.GetOrdersByCustomerAsync(x.CustomerId)));
        }

        private List<CustomerDetail> _customerDetails;

        private CustomerDetail _customerDetail;

        public CustomerDetail CustomerDetail
        {
            get { return _customerDetail; }
            set
            {
                SetProperty(ref _customerDetail, value);
            }
           
        }

        private string _customerId;

        public string CustomerId
        {
            get { return _customerId; }
            set
            {
                SetProperty(ref _customerId, value);
                OnSearch();
            }
        }

        private string _avgQty;

        public string AvgQty
        {
            get { return _avgQty; }
            set
            {
                SetProperty(ref _avgQty, value);
            }
        }

        private void OnSearch()
        {
            int intCustomerId;

            if (!int.TryParse(CustomerId, out intCustomerId))
            {
                ResetCustomers();

                return;
            }

            CustomerDetail = _customerDetails.FirstOrDefault(c => c.CustomerId == intCustomerId);

            if (CustomerDetail == null)
            {
                ResetCustomers();

                return;
            }

            AvgQty = CustomerDetail.Orders.Average(o => o.Quantity).ToString("0.##");
        }

        private void ResetCustomers()
        {
            CustomerDetail = new CustomerDetail
            {
                Orders = new ObservableCollection<Order>()
            };

            AvgQty = "";
        }
    }
}
