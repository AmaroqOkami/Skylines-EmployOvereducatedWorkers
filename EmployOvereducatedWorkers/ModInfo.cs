using ICities;
using System.Collections.Generic;

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
                return MODNAME;
			}
        }

        public string Description
        {
            get { return "This mod aims at helping low-level buildings to employ overeducated workers."; }
        }
	}
    
    public sealed class LoadingExtension : LoadingExtensionBase
    {
        List<RedirectCallsState> m_redirectionStates = new List<RedirectCallsState>();

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (mode == LoadMode.LoadGame || mode == LoadMode.NewGame)
            {
                RedirectionHelper.RedirectCalls(m_redirectionStates, typeof(TransferManager), typeof(CustomTransferManager), "MatchOffers", 1);
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
    }
}