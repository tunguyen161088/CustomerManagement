using System.Collections.ObjectModel;
using Data;

namespace CustomerManagement.Orders
{
    public class CustomerDetail: ViewModelBase
    {
        private int _customerId;

        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                SetProperty(ref _customerId, value);
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private ObservableCollection<Order> _orders;

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                SetProperty(ref _orders, value);
            }
        }
    }
}
