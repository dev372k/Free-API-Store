using Shared.Statics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Statics
{
    public class APIList
    {
        public static List<GetAPIs> list = new List<GetAPIs>
        {
            new GetAPIs
            {
                GroupBy = "Auth",
                APIs = new List<API>
                {
                    new API
                        {
                            Id = 1,
                            Name = "Login",
                            Endpoint = "api/auth/login",
                            Method = Shared.enMethodType.Post,
                            Request = @"",
                            Response = @"",
                            UniqueName= "login",
                        },
                        new API
                        {
                            Id = 1,
                            Name = "Register",
                            Endpoint = "api/auth/register",
                            Method = Shared.enMethodType.Post,
                            Request = @"",
                            Response = @"",
                            UniqueName = "register",
                        }
                }
            },
            new GetAPIs
            {
                GroupBy = "Product",
                APIs = new List<API>
                {
                    new API
                        {
                            Id = 1,
                            Name = "Create",
                            Endpoint = "api/product",
                            Method = Shared.enMethodType.Post,
                            Request = @"",
                            Response = @"",
                            UniqueName= "product-create",
                        },
                        new API
                        {
                            Id = 2,
                            Name = "Get All",
                            Endpoint = "api/product",
                            Method = Shared.enMethodType.Get,
                            Request = @"",
                            Response = @"",
                            UniqueName = "product-getall",
                        },
                        new API
                        {
                            Id = 3,
                            Name = "Get By Id",
                            Endpoint = "api/product/{id}",
                            Method = Shared.enMethodType.Get,
                            Request = @"",
                            Response = @"",
                            UniqueName = "product-getbyid",
                        },
                        new API
                        {
                            Id = 4,
                            Name = "Update",
                            Endpoint = "api/product/{id}",
                            Method = Shared.enMethodType.Put,
                            Request = @"",
                            Response = @"",
                            UniqueName = "product-update",
                        },
                        new API
                        {
                            Id = 5,
                            Name = "Delete",
                            Endpoint = "api/product/{id}",
                            Method = Shared.enMethodType.Delete,
                            Request = @"",
                            Response = @"",
                            UniqueName = "product-delete",
                        }
                }
            },
            new GetAPIs
            {
                GroupBy = "Category",
                APIs = new List<API>
                {
                    new API
                        {
                            Id = 1,
                            Name = "Create",
                            Endpoint = "api/category",
                            Method = Shared.enMethodType.Post,
                            Request = @"",
                            Response = @"",
                            UniqueName= "category-create",
                        },
                        new API
                        {
                            Id = 2,
                            Name = "Get All",
                            Endpoint = "api/category?pageNo=1&pageSize=10",
                            Method = Shared.enMethodType.Get,
                            Request = @"",
                            Response = @"{
                                ""status"": true,
                                ""message"": """",
                                ""data"": [
                                    {
                                        ""id"": 1,
                                        ""name"": ""Test"",
                                        ""createdOn"": ""0001-01-01T00:00:00""
                                    }
                                ],
                                ""errorMessage"": """",
                                ""errorDetails"": """"
                            }",
                            UniqueName = "category-getall",
                        },
                        //new API
                        //{
                        //    Id = 3,
                        //    Name = "Get By Id",
                        //    Endpoint = "api/category/{id}",
                        //    Method = Shared.enMethodType.Get,
                        //    Request = @"",
                        //    Response = @"",
                        //    UniqueName = "category-getbyid",
                        //},
                        new API
                        {
                            Id = 4,
                            Name = "Update",
                            Endpoint = "api/category/{id}",
                            Method = Shared.enMethodType.Put,
                            Request = @"",
                            Response = @"",
                            UniqueName = "category-update",
                        },
                        new API
                        {
                            Id = 5,
                            Name = "Delete",
                            Endpoint = "api/order/{id}",
                            Method = Shared.enMethodType.Delete,
                            Request = @"",
                            Response = @"",
                            UniqueName = "order-delete",
                        }
                }
            },
            new GetAPIs
            {
                GroupBy = "Order",
                APIs = new List<API>
                {
                    new API
                        {
                            Id = 1,
                            Name = "Create",
                            Endpoint = "api/order",
                            Method = Shared.enMethodType.Post,
                            Request = @"",
                            Response = @"",
                            UniqueName= "order-create",
                        },
                        new API
                        {
                            Id = 2,
                            Name = "Get All",
                            Endpoint = "api/order",
                            Method = Shared.enMethodType.Get,
                            Request = @"",
                            Response = @"",
                            UniqueName = "order-getall",
                        },
                        new API
                        {
                            Id = 3,
                            Name = "Get By Id",
                            Endpoint = "api/order/{id}",
                            Method = Shared.enMethodType.Get,
                            Request = @"",
                            Response = @"",
                            UniqueName = "order-getbyid",
                        },
                        new API
                        {
                            Id = 4,
                            Name = "Update",
                            Endpoint = "api/order/{id}",
                            Method = Shared.enMethodType.Put,
                            Request = @"",
                            Response = @"",
                            UniqueName = "order-update",
                        },
                        new API
                        {
                            Id = 5,
                            Name = "Delete",
                            Endpoint = "api/order/{id}",
                            Method = Shared.enMethodType.Delete,
                            Request = @"",
                            Response = @"",
                            UniqueName = "order-delete",
                        }
                }
            }
        };
    }
}
