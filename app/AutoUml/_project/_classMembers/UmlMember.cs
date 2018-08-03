﻿using System.Collections.Generic;
using System.Reflection;

namespace AutoUml
{
    public abstract class UmlMember : IMetadataContainer
    {
        public abstract MemberInfo GetMemberInfo();
        public abstract void WriteTo(CodeWriter cf, UmlProjectDiagram diagram);
        public int                        Group      { get; set; }
        public string                     Name       { get; set; }
        public bool                       HideOnList { get; set; }
        public Dictionary<string, object> Metadata   { get; } = new Dictionary<string, object>();
    }
}