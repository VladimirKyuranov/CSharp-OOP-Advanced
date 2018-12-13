namespace Solid.Logger.Layouts.Factory
{
    using Layouts.Contracts;
    using Layouts.Factory.Contracts;
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeAsLowerCase = type.ToLower();

            switch (typeAsLowerCase)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layouttype!");
            }
        }
    }
}
