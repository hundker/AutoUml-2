﻿using System;
using JetBrains.Annotations;

namespace AutoUml
{
    /// <summary>
    ///     Use it when additional relation is necessary
    /// </summary>
    [AttributeUsage(AttributesConsts.Entities, AllowMultiple = true)]
    public class UmlAddRelationAttribute : BaseRelationAttribute
    {
        public UmlAddRelationAttribute([NotNull] Type relatedType, 
            string name,
            UmlRelationKind kind = UmlRelationKind.Aggregation) : base(kind)
        {
            RelatedType = relatedType;
            Name        = name;
        }
        
        public bool   Multiple    { get; set; }
    }
}