using ICities;
using System.Collections.Generic;
using ColossalFramework;
using UnityEngine;
using System.Reflection;
using TrafficManager_ImprovedAI.Extensions;

namespace EmployOvereducatedWorkers
{
	public class ModInfo : IUserMod
	{
		public string MODNAME = "Employ Overeducated Workers";

		List<RedirectCallsState> m_redirectionStates = new List<RedirectCallsState>();

		public RedirectCallsState[] revertMethods = new RedirectCallsState[8];

		public string Name
		{
			get
			{
                //RedirectionHelper.RedirectCalls(null, typeof(TransferManager), typeof(CustomTransferManager), "MatchOffers", 1);
                return MODNAME;
			}
        }

        public string Description
        {
            get { return "This mod aims at helping low-level buildings to employ overeducated workers."; }
        }
	}
    /*
    public sealed class ThreadingExtension : ThreadingExtensionBase
    {
        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            base.OnUpdate(realTimeDelta, simulationTimeDelta);

            if (LoadingExtension.Instance == null)
            {
                return;
            }
            if (!LoadingExtension.Instance.detourInited)
            {
                RedirectionHelper.RedirectCalls(null, typeof(TransferManager), typeof(CustomTransferManager), "MatchOffers", 1);
                RedirectionHelper.RedirectCalls(null, typeof(CustomTransferManager), typeof(TransferManager), "StartTransfer", 3);

                LoadingExtension.Instance.detourInited = true;
            }
        }
    }
    */
    
    public sealed class LoadingExtension : LoadingExtensionBase
    {
        public static LoadingExtension Instance = null;
        public bool detourInited = false;
        List<RedirectCallsState> m_redirectionStates = new List<RedirectCallsState>();

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (mode == LoadMode.LoadGame || mode == LoadMode.NewGame)
            {
                //ReplaceTransferManager();
                RedirectionHelper.RedirectCalls(m_redirectionStates, typeof(TransferManager), typeof(CustomTransferManager), "MatchOffers", 1);
                //RedirectionHelper.RedirectCalls(m_redirectionStates, typeof(CustomTransferManager), typeof(TransferManager), "StartTransfer", 3);
                if (Instance == null)
                {
                    Instance = this;
                }
            }
        }

        public override void OnLevelUnloading()
        {
            base.OnLevelUnloading();
            foreach (RedirectCallsState rcs in m_redirectionStates)
            {
                RedirectionHelper.RevertRedirect(rcs);
            }
        }
        /*
        void ReplaceTransferManager()
        {
            if (Singleton<TransferManager>.instance as CustomTransferManager != null)
                return;

            // Change PathManager to CustomPathManager
            FieldInfo sInstance = typeof(ColossalFramework.Singleton<TransferManager>).GetFieldByName("sInstance");
            TransferManager originalTransferManager = ColossalFramework.Singleton<TransferManager>.instance;
            CustomTransferManager customTransferManager = originalTransferManager.gameObject.AddComponent<CustomTransferManager>();
            customTransferManager.SetOriginalValues(originalTransferManager);

            // change the new instance in the singleton
            sInstance.SetValue(null, customTransferManager);

            // change the manager in the SimulationManager
            FastList<ISimulationManager> managers = (FastList<ISimulationManager>)typeof(SimulationManager).GetFieldByName("m_managers").GetValue(null);
            managers.Remove(originalTransferManager);
            managers.Add(customTransferManager);

            // Destroy in 10 seconds to give time to all references to update to the new manager without crashing
            GameObject.Destroy(originalTransferManager, 10f);
        }*/
    }
}