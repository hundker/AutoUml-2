using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace AutoUml
{
    public class UmlAddMetaAttributeVisitor : IDiagramVisitor
    {
        private static void UpdateContainerFromAttributes(IMetadataContainer target, [CanBeNull]MemberInfo mi)
        {
            if (mi == null)
                return;
            var atts = mi.GetCustomAttributes(false).OfType<UmlAddMetaAttribute>();
            foreach (var attribute in atts)
                target.Metadata[attribute.Name] = attribute.ValueString;
        }

        public void VisitBeforeEmit(UmlDiagram diagram)
        {
            foreach (var info in diagram.GetEntities())
            {
                UpdateContainerFromAttributes(info, info.Type);
                foreach (var i in info.Members)
                    UpdateContainerFromAttributes(i, i.GetMemberInfo());
            }
        }

        public void VisitDiagramCreated(UmlDiagram diagram)
        {
        }
    }
}