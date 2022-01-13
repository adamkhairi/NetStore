namespace NetStore.Api.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        public static class Category
        {
            public const string GetAll = Base + "/Categories";
            public const string Create = Base + "/Categories";
            public const string Get = Base + "/Categories/{id}";
            public const string Update = Base + "/Categories/{id}";
            public const string Delete = Base + "/Categories/{id}";
        }
        public static class Product
        {
            public const string GetAll = Base + "/Products";
            public const string Create = Base + "/Products";
            public const string Get = Base + "/Products/{id}";
            public const string GetTopProducts = Base + "/Products/TopProducts/{id}";
            public const string GetByCat = Base + "/Products/GetByCategory/{id}";
            public const string Update = Base + "/Products/{id}";
            public const string Delete = Base + "/Products/{id}";
        }
        public static class CarteItems
        {
            public const string Get = Base + "/Cart/{id}";
            public const string Post = Base + "/Cart";
            public const string Delete = Base + "/Cart/{id}";
            public const string SubTotal = Base + "/Cart/SubTotal/{id}";
            public const string CountItems = Base + "/Cart/CountItems/{id}";
            //public const string Update = Base + "/Cart/{id}";
        }
        public static class Orders
        {
            public const string GetAll = Base + "/Orders";
            public const string Get = Base + "/Orders/{id}";
            public const string UserOrders = Base + "/Orders/UserOrders/{id}";
            public const string Pending = Base + "/Orders/PendingOrders";
            public const string Completed = Base + "/Orders/PendingOrders";
            public const string Count = Base + "/Orders/Count";
            public const string MarkComplete = Base + "/Orders/{id}";
            public const string Create = Base + "/Orders";
            //public const string Update = Base + "/Orders/{id}";
            //public const string Delete = Base + "/Orders/{id}";
        }
        public static class Contacts
        {
            public const string Get = Base + "/Contacts";
            public const string Create = Base + "/Contacts";
        }
    }
}
