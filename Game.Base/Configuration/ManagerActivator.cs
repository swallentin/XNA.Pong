using System;
using System.Reflection;

namespace Game.Base.Configuration
{
    public sealed class ManagerActivator
    {
        public static object CreateInstance(Type type, Microsoft.Xna.Framework.Game game)
        {
            if (type == null)
            {
                throw new ArgumentNullException("Manager Type");
            }

            ConstructorInfo info = type.GetConstructor(new Type[] { typeof(Microsoft.Xna.Framework.Game) });

            if (info == null)
            {
                return null;
            }

            object instance;

            try
            {
                instance = info.Invoke(new object[] { game });
            }
            catch (Exception ex)
            {
                if (ex is SystemException)
                {
                    throw;
                }
                instance = null;
            }
            return instance;
        }
    }
}