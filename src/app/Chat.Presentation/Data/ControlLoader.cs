using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;

namespace Chat.Presentation.UI.Data
{
    public class ControlLoader
    {
        public UserControl LoadControl(string userControlPath, Page page, params object[] constructorParameters)
        {
            var constParamTypes = new List<Type>();
            foreach (object constParam in constructorParameters)
            {
                constParamTypes.Add(constParam.GetType());
            }

            UserControl control = page.LoadControl(userControlPath) as UserControl;

            // Find the relevant constructor
            ConstructorInfo constructor = control.GetType().BaseType.GetConstructor(constParamTypes.ToArray());

            //And then call the relevant constructor
            if (constructor == null)
            {
                throw new MemberAccessException(string.Format("The requested constructor was not found on : {0}", control.GetType().BaseType.ToString()));
            }
            constructor.Invoke(control, constructorParameters);

            // Finally return the fully initialized UC
            return control;
        }
    }
}