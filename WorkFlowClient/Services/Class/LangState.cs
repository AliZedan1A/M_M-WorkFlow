
namespace WorkFlowClient.Services.Class
{
    public class LangState
    {
        public string Code { get; private set; } = "he"; // he / ar / en
        public bool IsRtl => Code is "he" or "ar";
        public string Dir => IsRtl ? "rtl" : "ltr";
        public string DisplayCode => Code switch { "he" => "HE", "ar" => "AR", _ => "EN" };

        private readonly Dictionary<string, Dictionary<string, string>> _dict = new()
        {
            ["he"] = new()
            {
                ["home"] = "בית",
                ["myShifts"] = "המשמרות שלי",
                ["logout"] = "התנתקות",
                ["admin"] = "מערכת ניהול",
                ["welcome"] = "ברוך הבא",
                ["Login"] = "התחברות",
                ["quickActions"] = "פעולות מהירות"
            },
            ["ar"] = new()
            {
                ["home"] = "الرئيسية",
                ["myShifts"] = "وردياتي",
                ["logout"] = "تسجيل خروج",
                ["admin"] = "نظام الإدارة",
                ["Login"] = "تسجيل دخول",
                ["welcome"] = "أهلًا بك",
                ["quickActions"] = "إجراءات سريعة"
            },
            ["en"] = new()
            {
                ["home"] = "Home",
                ["myShifts"] = "My Shifts",
                ["Login"] = "Login",
                ["logout"] = "Logout",
                ["admin"] = "Admin",
                ["welcome"] = "Welcome",
                ["quickActions"] = "Quick Actions"
            }
        };

        public string T(string key) => _dict.TryGetValue(Code, out var lang) && lang.TryGetValue(key, out var v) ? v : key;
        public void Set(string code) { Code = code; }
    }
}
