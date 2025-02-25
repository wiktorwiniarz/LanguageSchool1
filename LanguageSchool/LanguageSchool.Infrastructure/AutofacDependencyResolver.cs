﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using LanguageSchool;

namespace LanguageSchool.Infrastructure
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacDependencyResolver(ILifetimeScope lifetimeScope)
        {
            this._lifetimeScope = lifetimeScope;
        }

        public T ResolveOrDefault<T>() where T : class
            => _lifetimeScope.ResolveOptional<T>();
    }
}
