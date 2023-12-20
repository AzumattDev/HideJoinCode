using HarmonyLib;
using TMPro;

namespace HideJoinCode;

[HarmonyPatch(typeof(JoinCode), nameof(JoinCode.Update))]
static class JoinCodeUpdatePatch
{
    static void Prefix(JoinCode __instance)
    {
        if (!__instance.m_inMenu && __instance.m_isVisible <= 0.0)
            return;
        __instance.m_btn.gameObject.GetComponentInChildren<TMP_Text>().text = "";
        JoinCode.Hide();
    }

    static void Postfix(JoinCode __instance)
    {
        if (!__instance.m_inMenu && __instance.m_isVisible <= 0.0)
            return;
        __instance.m_btn.gameObject.GetComponentInChildren<TMP_Text>().text = "";
        JoinCode.Hide();
    }
}