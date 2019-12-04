using System;

namespace PageObjectExample
{
    internal class NotePage
    {
        internal NotePage AddComment(ExampleComment exampleComment)
        {
           return new NotePage();
        }

        internal bool Has(ExampleComment exampleComment)
        {
            return false;
        }
    }
}