﻿using Harmony;
using UnityEngine;
using static CaiLib.Logger.Logger;

namespace OilWellAnyWater
{
	public class OilWellAnyWaterPatches
	{
		public static class Mod_OnLoad
		{
			public static void OnLoad()
			{
				LogInit(ModInfo.Name, ModInfo.Version);
			}
		}

		[HarmonyPatch(typeof(OilWellCapConfig))]
		[HarmonyPatch(nameof(OilWellCapConfig.ConfigureBuildingTemplate))]
		public class OilWellCapConfig_ConfigureBuildingTemplate_Patch
		{
			public static void Postfix(ref GameObject go)
			{
				var elementConverter = go.AddOrGet<ElementConverter>();
				elementConverter.consumedElements = new[]
				{
					new ElementConverter.ConsumedElement(GameTags.AnyWater, 1f)
				};
			}
		}
	}
}