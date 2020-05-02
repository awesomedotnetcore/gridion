﻿// <copyright file="GridionService.cs" company="Gridion">
//     Copyright (c) 2019-2020, Alex Efremov (https://github.com/alexander-efremov)
// </copyright>
// 
// Licensed to the Apache Software Foundation (ASF) under one or more
// contributor license agreements.  See the NOTICE file distributed with
// this work for additional information regarding copyright ownership.
// The ASF licenses this file to You under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with
// the License.  You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// The latest version of this file can be found at https://github.com/gridion/gridion

namespace Gridion.Core.Services
{
    using Gridion.Core.Interfaces.Internals;

    /// <summary>
    ///     Represents a base <see cref="Gridion.Core.IGridion" /> service.
    /// </summary>
    /// <inheritdoc cref="Disposable" />
    /// <inheritdoc cref="IGridionService" />
    internal abstract class GridionService : Disposable, IGridionService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GridionService" /> class.
        /// </summary>
        /// <param name="name">
        ///     The name of a <see cref="IGridionService" /> instance.
        /// </param>
        protected GridionService(string name)
        {
            this.Name = name;
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="GridionService" /> class.
        /// </summary>
        /// <inheritdoc cref="Disposable" />
        ~GridionService()
        {
            this.DisposeUnmanaged();
        }

        /// <inheritdoc />
        public bool IsRunning { get; private set; }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public virtual void Start()
        {
            this.IsRunning = true;
        }

        /// <inheritdoc />
        public virtual void Stop()
        {
            this.IsRunning = false;
        }

        /// <inheritdoc />
        protected override void DisposeManaged()
        {
            base.DisposeManaged();

            if (this.IsRunning)
            {
                this.Stop();
            }
        }
    }
}