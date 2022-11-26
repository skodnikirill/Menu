using Menu.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Menu.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            Orders = new ObservableCollection<Food>();
            Foods = GetFoods();
        }
        public int OrderCount => Orders.Count;

        public float TotalPrice => Orders.Sum(x => x.Price);

        private ObservableCollection<Food> foods;

        public ObservableCollection<Food> Foods
        {
            get { return foods; }
            set
            {
                foods = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Food> orders;
        public ObservableCollection<Food> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(OrderCount));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private ObservableCollection<Food> GetFoods()
        {
            return new ObservableCollection<Food>
            {
                new Food{ Name = "Omelette Breakfast Dish", Image = "Omelette.png", Price = 13.99f, Description = "Яйця,сир твердий,ковбаса напівкопчена,олія оливкова,спеції,зелень"},
                new Food{ Name = "California", Image = "California.jpg", Price = 22.59f, Description ="Водорості норі,олія,свіжий огірок,авокадо,слабосолений лосось,лайм"},
                new Food{ Name = "Greek Salad with tomatoes", Image = "Greek.jpg", Price = 18.25f, Description ="Помідори,лайм,огірок,цибуля,оливки,сир Фета,орегано,спеції"},
                new Food{ Name = "Cherry with pepper salad", Image = "Cherry.jpg", Price = 10.99f, Description ="Помідори чері,перець болгарський,стейк,салат,рукула,спецї"},
            };
        }

        public void AddOrder(Food item)
        {
            if (item != null)
            {
                Orders.Add(item);
                OnPropertyChanged(nameof(OrderCount));
                OnPropertyChanged(nameof(TotalPrice));

            }
        }

    }
}
