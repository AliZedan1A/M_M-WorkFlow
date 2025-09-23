namespace WorkFlowClient.Services.Class
{
    public class LangState
    {
        public string Code { get; private set; } = "he"; // he / ar / en / ti
        public bool IsRtl => Code is "he" or "ar" or "ti";
        public string Dir => IsRtl ? "rtl" : "ltr";
        public string DisplayCode => Code switch
        {
            "he" => "HE",
            "ar" => "AR",
            "en" => "EN",
            "ti" => "TI",
            _ => "EN"
        };

        private readonly Dictionary<string, Dictionary<string, string>> _dict = new()
        {
            // ===== Hebrew =====
            ["he"] = new()
            {
                // (قديم عندك)
                ["home"] = "בית",
                ["myShifts"] = "המשמרות שלי",
                ["logout"] = "התנתקות",
                ["admin"] = "מערכת ניהול",
                ["welcome"] = "ברוך הבא",
                ["Login"] = "התחברות",
                ["quickActions"] = "פעולות מהירות",
                ["home"] = "דף הבית",
                ["confirmstart"] = "האם אתה בטוח שברצונך להתחיל משמרת חדשה?",
                ["confirmEnd"] = " האם אתה בטוח שברצונך לסיים את המשמרת הנוכחית? ",


                // (جديد – Admin)
                ["usersRequests"] = "בקשות משתמשים",
                ["shiftsRequests"] = "משמרות",
                ["userManagement"] = "ניהול משתמשים",

                // (جديد – Home/Alerts/Modal)
                ["accountPending"] = "⏳ החשבון שלך ממתין לאישור מנהל.",
                ["accountRejected"] = "❌ החשבון שלך נדחה. הירשם שוב.",
                ["noShift"] = "אין משמרת כרגע",
                ["startShift"] = "התחל משמרת",
                ["endShift"] = "סיים משמרת",
                ["activeShift"] = "משמרת פעילה",
                ["shiftNote"] = "באפשרותך להתחיל משמרת חדשה על ידי לחיצה על הכפתור למטה",
                ["pendingShifts"] = "יש לך {0} משמרות בהמתנה לאישור",
                ["myShiftsTitle"] = "📅 המשמרות שלי",
                ["chooseMonth"] = "בחר חודש:",
                ["chooseYear"] = "בחר שנה:",
                ["noAcceptedShifts"] = "אין לך משמרות מאושרות בחודש זה.",
                ["guestWelcome"] = "👋 ברוך הבא",
                ["guestSubtitle"] = "אנא התחבר כדי להמשיך ולהשתמש במערכת",
                ["aboutSystem"] = "ℹ️ אודות המערכת",
                ["confirmAction"] = "אישור פעולה",
                ["confirm"] = "אישור",
                ["cancel"] = "ביטול",
                ["confirmStart"] = "האם אתה בטוח שברצונך להתחיל משמרת חדשה?",
                ["confirmEnd"] = "האם אתה בטוח שברצונך לסיים את המשמרת הנוכחית?",
                //login
                ["otpLogin"] = "התחברות עם קוד אימות (OTP)",
                ["otpSubtitle"] = "אנא בחר מדינה והזן את מספר הטלפון שלך לשליחת קוד אימות.",
                ["otpCountry"] = "מדינה",
                ["otpUsername"] = "שם משתמש",
                ["otpPhone"] = "מספר טלפון",
                ["otpSend"] = "שלח קוד",
                ["otpSending"] = "שולח...",
                ["otpSentTo"] = "קוד נשלח אל {0} {1}. הזן אותו למטה.",
                ["otpCode"] = "קוד אימות",
                ["otpConfirm"] = "אשר קוד",
                ["otpVerifying"] = "מאמת...",
                ["otpResend"] = "🔄 שלח שוב קוד",
                ["otpResendAfter"] = "תוכל לשלוח שוב בעוד: {0} שניות",
                ["ws"] = "הגדה המערבית",
                ["il"] = "ישראל",
                ["jo"] = "ירדן"
            },

            // ===== Arabic =====
            ["ar"] = new()
            {
                // (قديم عندك)
                ["home"] = "الرئيسية",
                ["myShifts"] = "وردياتي",
                ["logout"] = "تسجيل خروج",
                ["admin"] = "نظام الإدارة",
                ["Login"] = "تسجيل دخول",
                ["welcome"] = "أهلًا بك",
                ["quickActions"] = "إجراءات سريعة",
                ["home"] = "الرئيسية",
                ["confirmstart"] = "هل أنت متأكد أنك تريد بدء وردية جديدة؟",
                ["confirmEnd"] = "هل أنت متأكد أنك تريد إنهاء الوردية الحالية؟",
                // (جديد – Admin)
                ["usersRequests"] = "طلبات المستخدمين",
                ["shiftsRequests"] = "الورديات",
                ["userManagement"] = "إدارة المستخدمين",

                // (جديد – Home/Alerts/Modal)
                ["accountPending"] = "⏳ حسابك قيد المراجعة، يرجى الانتظار حتى موافقة الإدارة.",
                ["accountRejected"] = "❌ تم رفض حسابك، يرجى التسجيل مرة أخرى.",
                ["noShift"] = "لا يوجد وردية حالياً",
                ["startShift"] = "بدء وردية",
                ["endShift"] = "إنهاء الوردية",
                ["activeShift"] = "وردية جارية",
                ["shiftNote"] = "يمكنك بدء وردية جديدة بالضغط على الزر أدناه",
                ["pendingShifts"] = "انت تملك {0} ورديات بانتظار القبول",
                ["myShiftsTitle"] = "📅 وردياتي",
                ["chooseMonth"] = "اختر الشهر:",
                ["chooseYear"] = "اختر السنة:",
                ["noAcceptedShifts"] = "لا يوجد لديك ورديات مقبولة في هذا الشهر.",
                ["guestWelcome"] = "👋 مرحباً بك",
                ["guestSubtitle"] = "يرجى تسجيل الدخول للمتابعة واستخدام النظام",
                ["aboutSystem"] = "ℹ️ عن النظام",
                ["confirmAction"] = "تأكيد العملية",
                ["confirm"] = "تأكيد",
                ["cancel"] = "إلغاء",
                ["confirmStart"] = "هل أنت متأكد أنك تريد بدء وردية جديدة؟",
                ["confirmEnd"] = "هل أنت متأكد أنك تريد إنهاء الوردية الحالية؟"
                ,
                //login
                ["otpLogin"] = "تسجيل الدخول برمز تحقق (OTP)",
                ["otpSubtitle"] = "الرجاء اختيار الدولة وإدخال رقم هاتفك لإرسال رمز تحقق.",
                ["otpCountry"] = "الدولة",
                ["otpUsername"] = "اسم المستخدم",
                ["otpPhone"] = "رقم الهاتف",
                ["otpSend"] = "إرسال الكود",
                ["otpSending"] = "جاري الإرسال...",
                ["otpSentTo"] = "تم إرسال الكود إلى {0} {1}. يرجى إدخاله أدناه.",
                ["otpCode"] = "رمز التحقق",
                ["otpConfirm"] = "تأكيد الكود",
                ["otpVerifying"] = "جاري التحقق...",
                ["otpResend"] = "🔄 إعادة إرسال الكود",
                ["otpResendAfter"] = "يمكنك إعادة الإرسال بعد: {0} ثانية",
                ["ws"] = "الضفة",
                ["il"] = "اسرائيل",
                ["jo"] = "الاردن"

            },

            // ===== English =====
            ["en"] = new()
            {
                // (قديم عندك)
                ["home"] = "Home",
                ["myShifts"] = "My Shifts",
                ["Login"] = "Login",
                ["logout"] = "Logout",
                ["admin"] = "Admin",
                ["welcome"] = "Welcome",
                ["quickActions"] = "Quick Actions",
                ["home"] = "Home",
                // (جديد – Admin)
                ["usersRequests"] = "User Requests",
                ["shiftsRequests"] = "Shifts",
                ["userManagement"] = "User Management",
                ["confirmstart"] = "Are you sure you want to start a new shift?",
                ["confirmEnd"] = "Are you sure you want to end the current shift?",

                // (جديد – Home/Alerts/Modal)
                ["accountPending"] = "⏳ Your account is under review, please wait for admin approval.",
                ["accountRejected"] = "❌ Your account was rejected, please register again.",
                ["noShift"] = "No active shift",
                ["startShift"] = "Start Shift",
                ["endShift"] = "End Shift",
                ["activeShift"] = "Active Shift",
                ["shiftNote"] = "You can start a new shift by clicking the button below",
                ["pendingShifts"] = "You have {0} shifts pending approval",
                ["myShiftsTitle"] = "📅 My Shifts",
                ["chooseMonth"] = "Choose Month:",
                ["chooseYear"] = "Choose Year:",
                ["noAcceptedShifts"] = "No accepted shifts this month.",
                ["guestWelcome"] = "👋 Welcome",
                ["guestSubtitle"] = "Please login to continue using the system",
                ["aboutSystem"] = "ℹ️ About the system",
                ["confirmAction"] = "Confirm Action",
                ["confirm"] = "Confirm",
                ["cancel"] = "Cancel",
                ["confirmStart"] = "Are you sure you want to start a new shift?",
                ["confirmEnd"] = "Are you sure you want to end the current shift?",
                //login
                ["otpLogin"] = "Login with Verification Code (OTP)",
                ["otpSubtitle"] = "Please select a country and enter your phone number to send a verification code.",
                ["otpCountry"] = "Country",
                ["otpUsername"] = "Username",
                ["otpPhone"] = "Phone Number",
                ["otpSend"] = "Send Code",
                ["otpSending"] = "Sending...",
                ["otpSentTo"] = "The code has been sent to {0} {1}. Please enter it below.",
                ["otpCode"] = "Verification Code",
                ["otpConfirm"] = "Confirm Code",
                ["otpVerifying"] = "Verifying...",
                ["otpResend"] = "🔄 Resend Code",
                ["otpResendAfter"] = "You can resend after: {0} seconds",
                ["ws"] = "West Bank",
                ["il"] = "Israel",
                ["jo"] = "Jordan"

            },

         

            // ===== Tigrinya (إرتري) =====
            ["ti"] = new()
            {
                ["home"] = "መአልቲ",
                ["myShifts"] = "ዓመዓተይ",
                ["logout"] = "ኣውት ውጽእ",
                ["admin"] = "ኣስተዳደር",
                ["Login"] = "ግባ",
                ["welcome"] = "እንቋዕ ብደሓን መፁኡ",
                ["quickActions"] = "ቅልጡፍ ተግባራት",
                ["confirmstart"] = "እርግጠኛ ኢኻ ምስራሕ ሓዱሽ ክጀምር ትደሊ?",
                ["confirmEnd"] = "እርግጠኛ ኢኻ ናይ ሕጂ ምስራሕ ክዛረብ ትደሊ?",

                ["usersRequests"] = "መጠይቕታት ተጠቃሚ",
                ["shiftsRequests"] = "ምስራሕታት",
                ["userManagement"] = "ናይ ተጠቃሚ ኣስተዳደር",

                ["accountPending"] = "⏳ ናይካ መለለዪ ብምኽንያት ተመርመረ እዩ።",
                ["accountRejected"] = "❌ ናይካ መለለዪ ተኣፍልጦም። እንደገና ተመዝገብ።",
                ["noShift"] = "ምስራሕ የለን ሕጂ",
                ["startShift"] = "ጀምር ምስራሕ",
                ["endShift"] = "ይዛረብ ምስራሕ",
                ["activeShift"] = "ኣብ ስራሕ ዘሎ ምስራሕ",
                ["shiftNote"] = "ምስራሕ ሓዱሽ ክጀምር ትኽክል ዝኣተወ ቁልፊ ዝጽበቕ",
                ["pendingShifts"] = "ኣብ መርሕ ብምቕዳሕ {0} ምስራሕታት ኣለካ",
                ["myShiftsTitle"] = "📅 ዓመዓተይ",
                ["chooseMonth"] = "ኣትዮ ወርሒ:",
                ["chooseYear"] = "ኣትዮ ዓመት:",
                ["noAcceptedShifts"] = "ኣብዚ ወርሒ ምስራሕ የለን።",
                ["guestWelcome"] = "👋 እንቋዕ ብደሓን መፁኡ",
                ["guestSubtitle"] = "ቀፀልካ ናብ ስርዓት ክትጠቀም ትኽክል ግባ",
                ["aboutSystem"] = "ℹ️ ብዛዕባ ስርዓት",
                ["confirmAction"] = "ኣረጋግፅ ተግባር",
                ["confirm"] = "ኣረጋግፅ",
                ["cancel"] = "ሰርዝ",
                ["confirmStart"] = "ምስራሕ ሓዱሽ ክጀምር ትኽክል ኢኻ?",
                ["confirmEnd"] = "ናይ ሕጂ ምስራሕ ክዛረብ ትኽክል ኢኻ?",
                //login
                ["otpLogin"] = "ናይ OTP ኮድ ብትግበር ግባ",
                ["otpSubtitle"] = "እቲ ሃገር ምረጽ ንናይካ ስልኪ ቁጽሪ ኣእቱ ናይ ምርግጋእ ኮድ ክትልእኽ.",
                ["otpCountry"] = "ሃገር",
                ["otpUsername"] = "ስም ተጠቃሚ",
                ["otpPhone"] = "ቁጽሪ ስልኪ",
                ["otpSend"] = "ኮድ ላእቲ",
                ["otpSending"] = "እዩ ዝልእበሉ...",
                ["otpSentTo"] = "ኮድ ብምልኣኽ ኣብ {0} {1} ተላኢኹ። ብታሕቲ ኣእቱ.",
                ["otpCode"] = "ናይ ምርግጋእ ኮድ",
                ["otpConfirm"] = "ኮድ ኣረጋግፅ",
                ["otpVerifying"] = "እዩ ዝተረጋገፀ...",
                ["otpResend"] = "🔄 ኮድ እንደገና ላእቲ",
                ["otpResendAfter"] = "እንደገና ክትልእኽ ትኽክል ኣብ: {0} ሰከንድ",
                ["ws"] = "ምብራቕ ወንበር",
                ["il"] = "እስራኤል",
                ["jo"] = "ጆርዳን",
                ["home"]= "ዋና ገጽ"


            }
        };


        public string T(string key) =>
            _dict.TryGetValue(Code, out var lang) && lang.TryGetValue(key, out var v) ? v : key;

        public void Set(string code) => Code = code;
    }
}
