﻿// <copyright file="DictionaryCreatedMessage.cs" company="Gridion">
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

namespace Gridion.Core.Messages
{
    using System;

    using Gridion.Core.Collections;
    using Gridion.Core.Messages.Interfaces;

    /// <summary>
    /// Represents a message that indicating that dictionary was created on the sender.
    /// </summary>
    /// <inheritdoc cref="CollectionCreatedMessage"/>
    internal class DictionaryCreatedMessage : CollectionCreatedMessage
    {
        /// <summary>
        /// The type of key in a dictionary.
        /// </summary>
        private readonly Type keyType;

        /// <summary>
        /// The type of value in a dictionary.
        /// </summary>
        private readonly Type valType;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DictionaryCreatedMessage" /> class.
        /// </summary>
        /// <param name="sender">The message sender.</param>
        /// <param name="name">The name of the collection.</param>
        /// <param name="keyType">The type of key in a dictionary.</param>
        /// <param name="valType">The type of value in a dictionary.</param>
        /// <inheritdoc cref="CollectionCreatedMessage"/>
        public DictionaryCreatedMessage(ISender sender, string name, Type keyType, Type valType) 
            : base(sender, name)
        {
            this.keyType = keyType;
            this.valType = valType;
        }

        /// <inheritdoc />
        internal override IDistributedCollection Create()
        {
            var type = typeof(DistributedDictionary<,>);
            Type[] arguments = { this.keyType, this.valType };
            var constructed = type.MakeGenericType(arguments);
            var instance = Activator.CreateInstance(constructed, this.Name, this.Sender);
            return (IDistributedCollection)instance;
        }
    }
}