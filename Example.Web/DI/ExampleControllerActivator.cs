using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Autofac;
namespace Example.Web.DI
{
    
    public class ExampleControllerActivator : IHttpControllerActivator
    {
        private readonly IContainer _container;

        public ExampleControllerActivator(IContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController)_container.Resolve(controllerType);
            return controller;
        }
    }
}