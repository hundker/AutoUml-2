using System;
using System.Linq;

namespace AutoUml.Symbols
{
    public abstract class SymbolBaseVisitor : INewTypeInDiagramVisitor
    {
        public static void AddIcon(UmlDiagram diagram, SymbolInfo symbol)
        {
            var list = diagram.Legend.Items;
            var existing = list
                .OfType<SymbolTableUmlDiagramLegendItem>()
                .FirstOrDefault();
            if (existing is null)
            {
                existing = new SymbolTableUmlDiagramLegendItem();
                list.Add(existing);
            }

            existing.AddSymbol(symbol);
            //=============
        }

        public static void AddIcon(UmlEntity info, SymbolInfo symbolInfo)
        {
            var list = info.Members;
            var existing = list
                .OfType<SymbolLineUmlMember>()
                .FirstOrDefault();
            if (existing is null)
            {
                existing = new SymbolLineUmlMember();
                list.Add(existing);
            }

            existing.AddSymbol(symbolInfo.SymbolText);
        }

        public abstract void Visit(UmlDiagram diagram, UmlEntity info);

        protected PlantUmlText AddStyle(PlantUmlText text)
        {
            if (SymbolColor != null)
                text = text.WithFontColor(SymbolColor.Value);

            if (FontSize != null)
                text = text.WithFontSize(FontSize.Value);

            var h = AddStyleToSymbol;
            if (h is null)
                return text.WithFontSize(14);
            var q = new AddStyleToSymbolEventArgs
            {
                Text = text
            };
            h.Invoke(this, q);
            return q.Text;
        }

        public PlantUmlText Symbol      { get; set; }
        public UmlColor?    SymbolColor { get; set; }
        public int?         FontSize    { get; set; }

        public event EventHandler<AddStyleToSymbolEventArgs> AddStyleToSymbol;

        public class AddStyleToSymbolEventArgs : EventArgs
        {
            public PlantUmlText Text { get; set; }
        }
    }
}