﻿// <copyright file="AbstractDistributedQueue.cs" company="Gridion">
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

namespace Gridion.Core.Collections
{
    using System.Collections.Generic;

    /// <inheritdoc cref="Queue{T}" />
    internal abstract class AbstractDistributedQueue<T> : Queue<T>, IDistributedQueue<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Gridion.Core.Collections.AbstractDistributedQueue{T}" /> class.
        /// </summary>
        /// <param name="name">
        ///     The name of queue.
        /// </param>
        /// <inheritdoc cref="Queue{T}" />
        protected AbstractDistributedQueue(string name, INode parentNode)
        {
            this.Name = name;
            this.ParentNode = parentNode;
        }

        /// <inheritdoc />
        public string Name { get; }
        
        /// <inheritdoc />
        public INode ParentNode { get; }
    }
}