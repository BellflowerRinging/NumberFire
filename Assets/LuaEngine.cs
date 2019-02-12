using XLua;

public class LuaEngine
{
    public static LuaEnv luaEnv
    {
        get
        {
            if (env == null) env = new LuaEnv();
            return env;
        }
        private set { }
    }

    static LuaEnv env;
}