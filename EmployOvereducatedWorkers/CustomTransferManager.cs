using ColossalFramework;
using ColossalFramework.Plugins;
using System;
using System.Reflection;
using UnityEngine;

public class CustomTransferManager : SimulationManagerBase<TransferManager, TransferProperties>, ISimulationManager
{
    private void GetParams()
    {
        var inst = Singleton<TransferManager>.instance;
        var incomingCount = typeof(TransferManager).GetField("m_incomingCount", BindingFlags.NonPublic | BindingFlags.Instance);
        var incomingOffers = typeof(TransferManager).GetField("m_incomingOffers", BindingFlags.NonPublic | BindingFlags.Instance);
        var incomingAmount = typeof(TransferManager).GetField("m_incomingAmount", BindingFlags.NonPublic | BindingFlags.Instance);
        var outgoingCount = typeof(TransferManager).GetField("m_outgoingCount", BindingFlags.NonPublic | BindingFlags.Instance);
        var outgoingOffers = typeof(TransferManager).GetField("m_outgoingOffers", BindingFlags.NonPublic | BindingFlags.Instance);
        var outgoingAmount = typeof(TransferManager).GetField("m_outgoingAmount", BindingFlags.NonPublic | BindingFlags.Instance);
        if (inst == null)
        {
            CODebugBase<LogChannel>.Error(LogChannel.Core, "No instance of TransferManager found!");
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Error, "No instance of TransferManager found!");
            return;
        }
        m_incomingCount = incomingCount.GetValue(inst) as ushort[];
        m_incomingOffers = incomingOffers.GetValue(inst) as TransferManager.TransferOffer[];
        m_incomingAmount = incomingAmount.GetValue(inst) as int[];
        m_outgoingCount = outgoingCount.GetValue(inst) as ushort[];
        m_outgoingOffers = outgoingOffers.GetValue(inst) as TransferManager.TransferOffer[];
        m_outgoingAmount = outgoingAmount.GetValue(inst) as int[];
    }

    private void SetParams()
    {
        var inst = Singleton<TransferManager>.instance;
        var incomingCount = typeof(TransferManager).GetField("m_incomingCount", BindingFlags.NonPublic | BindingFlags.Instance);
        var incomingOffers = typeof(TransferManager).GetField("m_incomingOffers", BindingFlags.NonPublic | BindingFlags.Instance);
        var incomingAmount = typeof(TransferManager).GetField("m_incomingAmount", BindingFlags.NonPublic | BindingFlags.Instance);
        var outgoingCount = typeof(TransferManager).GetField("m_outgoingCount", BindingFlags.NonPublic | BindingFlags.Instance);
        var outgoingOffers = typeof(TransferManager).GetField("m_outgoingOffers", BindingFlags.NonPublic | BindingFlags.Instance);
        var outgoingAmount = typeof(TransferManager).GetField("m_outgoingAmount", BindingFlags.NonPublic | BindingFlags.Instance);
        if (inst == null)
        {
            CODebugBase<LogChannel>.Error(LogChannel.Core, "No instance of TransferManager found!");
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Error, "No instance of TransferManager found!");
            return;
        }
        incomingCount.SetValue(inst, m_incomingCount);
        incomingOffers.SetValue(inst, m_incomingOffers);
        incomingAmount.SetValue(inst, m_incomingAmount);
        outgoingCount.SetValue(inst, m_outgoingCount);
        outgoingOffers.SetValue(inst, m_outgoingOffers);
        outgoingAmount.SetValue(inst, m_outgoingAmount);
    }

    private TransferManager.TransferOffer[] m_outgoingOffers;

    private TransferManager.TransferOffer[] m_incomingOffers;

    private ushort[] m_outgoingCount;

    private ushort[] m_incomingCount;

    private int[] m_outgoingAmount;

    private int[] m_incomingAmount;

    private static float GetDistanceMultiplier(TransferManager.TransferReason material)
    {
        switch (material)
        {
            case TransferManager.TransferReason.Garbage:
                return 5E-07f;
            case TransferManager.TransferReason.Crime:
                return 1E-05f;
            case TransferManager.TransferReason.Sick:
                return 1E-06f;
            case TransferManager.TransferReason.Dead:
                return 1E-05f;
            case TransferManager.TransferReason.Worker0:
                return 1E-07f;
            case TransferManager.TransferReason.Worker1:
                return 1E-07f;
            case TransferManager.TransferReason.Worker2:
                return 1E-07f;
            case TransferManager.TransferReason.Worker3:
                return 1E-07f;
            case TransferManager.TransferReason.Student1:
                return 2E-07f;
            case TransferManager.TransferReason.Student2:
                return 2E-07f;
            case TransferManager.TransferReason.Student3:
                return 2E-07f;
            case TransferManager.TransferReason.Fire:
                return 1E-05f;
            case TransferManager.TransferReason.Bus:
                return 1E-05f;
            case TransferManager.TransferReason.Oil:
                return 1E-07f;
            case TransferManager.TransferReason.Ore:
                return 1E-07f;
            case TransferManager.TransferReason.Logs:
                return 1E-07f;
            case TransferManager.TransferReason.Grain:
                return 1E-07f;
            case TransferManager.TransferReason.Goods:
                return 1E-07f;
            case TransferManager.TransferReason.PassengerTrain:
                return 1E-05f;
            case TransferManager.TransferReason.Coal:
                return 1E-07f;
            case TransferManager.TransferReason.Family0:
                return 1E-08f;
            case TransferManager.TransferReason.Family1:
                return 1E-08f;
            case TransferManager.TransferReason.Family2:
                return 1E-08f;
            case TransferManager.TransferReason.Family3:
                return 1E-08f;
            case TransferManager.TransferReason.Single0:
                return 1E-08f;
            case TransferManager.TransferReason.Single1:
                return 1E-08f;
            case TransferManager.TransferReason.Single2:
                return 1E-08f;
            case TransferManager.TransferReason.Single3:
                return 1E-08f;
            case TransferManager.TransferReason.PartnerYoung:
                return 1E-08f;
            case TransferManager.TransferReason.PartnerAdult:
                return 1E-08f;
            case TransferManager.TransferReason.Shopping:
                return 2E-07f;
            case TransferManager.TransferReason.Petrol:
                return 1E-07f;
            case TransferManager.TransferReason.Food:
                return 1E-07f;
            case TransferManager.TransferReason.LeaveCity0:
                return 1E-08f;
            case TransferManager.TransferReason.LeaveCity1:
                return 1E-08f;
            case TransferManager.TransferReason.LeaveCity2:
                return 1E-08f;
            case TransferManager.TransferReason.Entertainment:
                return 2E-07f;
            case TransferManager.TransferReason.Lumber:
                return 1E-07f;
            case TransferManager.TransferReason.GarbageMove:
                return 5E-07f;
            case TransferManager.TransferReason.MetroTrain:
                return 1E-05f;
            case TransferManager.TransferReason.PassengerPlane:
                return 1E-05f;
            case TransferManager.TransferReason.PassengerShip:
                return 1E-05f;
            case TransferManager.TransferReason.DeadMove:
                return 5E-07f;
            case TransferManager.TransferReason.DummyCar:
                return -1E-08f;
            case TransferManager.TransferReason.DummyTrain:
                return -1E-08f;
            case TransferManager.TransferReason.DummyShip:
                return -1E-08f;
            case TransferManager.TransferReason.DummyPlane:
                return -1E-08f;
            case TransferManager.TransferReason.Single0B:
                return 1E-08f;
            case TransferManager.TransferReason.Single1B:
                return 1E-08f;
            case TransferManager.TransferReason.Single2B:
                return 1E-08f;
            case TransferManager.TransferReason.Single3B:
                return 1E-08f;
            case TransferManager.TransferReason.ShoppingB:
                return 2E-07f;
            case TransferManager.TransferReason.ShoppingC:
                return 2E-07f;
            case TransferManager.TransferReason.ShoppingD:
                return 2E-07f;
            case TransferManager.TransferReason.ShoppingE:
                return 2E-07f;
            case TransferManager.TransferReason.ShoppingF:
                return 2E-07f;
            case TransferManager.TransferReason.ShoppingG:
                return 2E-07f;
            case TransferManager.TransferReason.ShoppingH:
                return 2E-07f;
            case TransferManager.TransferReason.EntertainmentB:
                return 2E-07f;
            case TransferManager.TransferReason.EntertainmentC:
                return 2E-07f;
            case TransferManager.TransferReason.EntertainmentD:
                return 2E-07f;
            case TransferManager.TransferReason.Taxi:
                return 1E-05f;
            case TransferManager.TransferReason.CriminalMove:
                return 5E-07f;
            case TransferManager.TransferReason.Tram:
                return 1E-05f;
            case TransferManager.TransferReason.Snow:
                return 5E-07f;
            case TransferManager.TransferReason.SnowMove:
                return 5E-07f;
            case TransferManager.TransferReason.RoadMaintenance:
                return 5E-07f;
            default:
                return 1E-07f;
        }
    }

    private void MatchOffers(TransferManager.TransferReason material)
    {
        GetParams();
        
        float single;
        float single1;
        float single2;
        if (material == TransferManager.TransferReason.None)
        {
            return;
        }
        float distanceMultiplier = GetDistanceMultiplier(material);
        single = (distanceMultiplier == 0f ? 0f : 0.01f / distanceMultiplier);
        for (int i = 7; i >= 0; i--)
        {
            int num = (int)material * 8 + i;
            int mIncomingCount = m_incomingCount[num];//優先度iの求人票の数
            int mOutgoingCount = m_outgoingCount[num];//優先度iの求職者の数
            int num1 = 0;
            int num2 = 0;
            while (num1 < mIncomingCount || num2 < mOutgoingCount)
            {
                if (num1 < mIncomingCount)
                {
                    TransferManager.TransferOffer mIncomingOffers = m_incomingOffers[num * 256 + num1];//優先度iの求人票num1番目
                    Vector3 position = mIncomingOffers.Position;
                    int amount = mIncomingOffers.Amount; //その求人票の求人数

                    TransferManager.TransferReason material2 = material;
                    do
                    {
                        do
                        {
                            int num3 = Mathf.Max(0, 2 - i);
                            int num4 = -1;
                            int num5 = -1;
                            float single3 = -1f;
                            int num6 = num2;
                            int num7 = i;
                            while (num7 >= num3)
                            {
                                int num8 = (int)material2 * 8 + num7;
                                int mOutgoingCount1 = m_outgoingCount[num8];//求職者を優先度iから順に見ていく
                                float single4 = (float)num7 + 0.1f;
                                if (single3 < single4)
                                {
                                    for (int j = num6; j < mOutgoingCount1; j++)
                                    {
                                        TransferManager.TransferOffer mOutgoingOffers = m_outgoingOffers[num8 * 256 + j];
                                        float single5 = Vector3.SqrMagnitude(mOutgoingOffers.Position - position);
                                        single1 = (distanceMultiplier >= 0f ? single4 / (1f + single5 * distanceMultiplier) : single4 - single4 / (1f - single5 * distanceMultiplier));
                                        if (single1 > single3)
                                        {
                                            num4 = num7;
                                            num5 = j;
                                            single3 = single1;
                                            if (single5 < single)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    num6 = 0;
                                    num7--;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (num4 == -1)
                            {
                                break;//マッチング失敗
                            }
                            else
                            {
                                //マッチング成功、後処理
                                int num9 = (int)material2 * 8 + num4;
                                TransferManager.TransferOffer transferOffer = m_outgoingOffers[num9 * 256 + num5];
                                int amount1 = transferOffer.Amount;
                                int num10 = Mathf.Min(amount, amount1);//マッチングした数
                                if (num10 != 0)
                                {
                                    StartTransfer(material, transferOffer, mIncomingOffers);
                                }
                                amount = amount - num10;//求人票の残りの数
                                amount1 = amount1 - num10;//求職者の残りの数
                                if (amount1 != 0)
                                {
                                    //求職者の残りの数をセット
                                    transferOffer.Amount = amount1;
                                    m_outgoingOffers[num9 * 256 + num5] = transferOffer;
                                }
                                else
                                {
                                    int mOutgoingCount2 = m_outgoingCount[num9] - 1;
                                    m_outgoingCount[num9] = (ushort)mOutgoingCount2;
                                    m_outgoingOffers[num9 * 256 + num5] = m_outgoingOffers[num9 * 256 + mOutgoingCount2];
                                    if (num9 == num)
                                    {
                                        mOutgoingCount = mOutgoingCount2;
                                    }
                                }
                                mIncomingOffers.Amount = amount;
                            }
                        }
                        while (amount != 0);
                        if (amount == 0 || material2 < TransferManager.TransferReason.Worker0 || TransferManager.TransferReason.Worker3 <= material2) break;
                        material2++;
                    } while (true);
                    if (amount != 0)
                    {
                        //求人票の残りの数をセット
                        mIncomingOffers.Amount = amount;
                        m_incomingOffers[num * 256 + num1] = mIncomingOffers;
                        num1++;
                    }
                    else
                    {
                        mIncomingCount--;
                        m_incomingCount[num] = (ushort)mIncomingCount;
                        m_incomingOffers[num * 256 + num1] = m_incomingOffers[num * 256 + mIncomingCount];
                    }
                }
                if (num2 >= mOutgoingCount)
                {
                    continue;
                }
                TransferManager.TransferOffer mOutgoingOffers1 = m_outgoingOffers[num * 256 + num2];//優先度iの求職者num2番目
                Vector3 vector3 = mOutgoingOffers1.Position;
                int amount2 = mOutgoingOffers1.Amount;

                TransferManager.TransferReason material3 = material;
                do
                {
                    do
                    {
                        int num11 = Mathf.Max(0, 2 - i);
                        int num12 = -1;
                        int num13 = -1;
                        float single6 = -1f;
                        int num14 = num1;
                        int num15 = i;
                        while (num15 >= num11)
                        {
                            int num16 = (int)material3 * 8 + num15;
                            int mIncomingCount1 = m_incomingCount[num16];//求人票を優先度iから順に見ていく
                            float single7 = (float)num15 + 0.1f;
                            if (single6 < single7)
                            {
                                for (int k = num14; k < mIncomingCount1; k++)
                                {
                                    TransferManager.TransferOffer mIncomingOffers1 = m_incomingOffers[num16 * 256 + k];
                                    float single8 = Vector3.SqrMagnitude(mIncomingOffers1.Position - vector3);
                                    single2 = (distanceMultiplier >= 0f ? single7 / (1f + single8 * distanceMultiplier) : single7 - single7 / (1f - single8 * distanceMultiplier));
                                    if (single2 > single6)
                                    {
                                        num12 = num15;
                                        num13 = k;
                                        single6 = single2;
                                        if (single8 < single)
                                        {
                                            break;
                                        }
                                    }
                                }
                                num14 = 0;
                                num15--;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (num12 == -1)
                        {
                            break;//マッチング失敗
                        }
                        else
                        {
                            //マッチング成功、後処理
                            int num17 = (int)material3 * 8 + num12;
                            TransferManager.TransferOffer transferOffer1 = m_incomingOffers[num17 * 256 + num13];
                            int amount3 = transferOffer1.Amount;
                            int num18 = Mathf.Min(amount2, amount3);
                            if (num18 != 0)
                            {
                                StartTransfer(material, mOutgoingOffers1, transferOffer1);
                            }
                            amount2 = amount2 - num18;
                            amount3 = amount3 - num18;
                            if (amount3 != 0)
                            {
                                transferOffer1.Amount = amount3;
                                m_incomingOffers[num17 * 256 + num13] = transferOffer1;
                            }
                            else
                            {
                                int mIncomingCount2 = m_incomingCount[num17] - 1;
                                m_incomingCount[num17] = (ushort)mIncomingCount2;
                                m_incomingOffers[num17 * 256 + num13] = m_incomingOffers[num17 * 256 + mIncomingCount2];
                                if (num17 == num)
                                {
                                    mIncomingCount = mIncomingCount2;
                                }
                            }
                            mOutgoingOffers1.Amount = amount2;
                        }
                    }
                    while (amount2 != 0);
                    
                    if (amount2 == 0 || material3 <= TransferManager.TransferReason.Worker0 || TransferManager.TransferReason.Worker3 < material3) break;
                    material3--;
                } while (true);
                if (amount2 != 0)
                {
                    mOutgoingOffers1.Amount = amount2;
                    m_outgoingOffers[num * 256 + num2] = mOutgoingOffers1;
                    num2++;
                }
                else
                {
                    mOutgoingCount--;
                    m_outgoingCount[num] = (ushort)mOutgoingCount;
                    m_outgoingOffers[num * 256 + num2] = m_outgoingOffers[num * 256 + mOutgoingCount];
                }
            }
        }
        for (int l = 0; l < 8; l++)
        {
            int num19 = (int)material * 8 + l;
            m_incomingCount[num19] = 0;
            m_outgoingCount[num19] = 0;
        }
        m_incomingAmount[(int)material] = 0;
        m_outgoingAmount[(int)material] = 0;

        SetParams();
    }

    private static void StartTransfer(TransferManager.TransferReason material, TransferManager.TransferOffer offerOut, TransferManager.TransferOffer offerIn)
    {
        bool active = offerIn.Active;
        bool active2 = offerOut.Active;
        if (active && offerIn.Vehicle != 0)
        {
            Array16<Vehicle> vehicles = Singleton<VehicleManager>.instance.m_vehicles;
            ushort vehicle = offerIn.Vehicle;
            VehicleInfo info = vehicles.m_buffer[(int)vehicle].Info;
            info.m_vehicleAI.StartTransfer(vehicle, ref vehicles.m_buffer[(int)vehicle], material, offerOut);
        }
        else if (active2 && offerOut.Vehicle != 0)
        {
            Array16<Vehicle> vehicles2 = Singleton<VehicleManager>.instance.m_vehicles;
            ushort vehicle2 = offerOut.Vehicle;
            VehicleInfo info2 = vehicles2.m_buffer[(int)vehicle2].Info;
            info2.m_vehicleAI.StartTransfer(vehicle2, ref vehicles2.m_buffer[(int)vehicle2], material, offerIn);
        }
        else if (active && offerIn.Citizen != 0u)
        {
            Array32<Citizen> citizens = Singleton<CitizenManager>.instance.m_citizens;
            uint citizen = offerIn.Citizen;
            CitizenInfo citizenInfo = citizens.m_buffer[(int)((UIntPtr)citizen)].GetCitizenInfo(citizen);
            if (citizenInfo != null)
            {
                citizenInfo.m_citizenAI.StartTransfer(citizen, ref citizens.m_buffer[(int)((UIntPtr)citizen)], material, offerOut);
            }
        }
        else if (active2 && offerOut.Citizen != 0u)
        {
            Array32<Citizen> citizens2 = Singleton<CitizenManager>.instance.m_citizens;
            uint citizen2 = offerOut.Citizen;
            CitizenInfo citizenInfo2 = citizens2.m_buffer[(int)((UIntPtr)citizen2)].GetCitizenInfo(citizen2);
            if (citizenInfo2 != null)
            {
                citizenInfo2.m_citizenAI.StartTransfer(citizen2, ref citizens2.m_buffer[(int)((UIntPtr)citizen2)], material, offerIn);
            }
        }
        else if (active2 && offerOut.Building != 0)
        {
            Array16<Building> buildings = Singleton<BuildingManager>.instance.m_buildings;
            ushort building = offerOut.Building;
            BuildingInfo info3 = buildings.m_buffer[(int)building].Info;
            info3.m_buildingAI.StartTransfer(building, ref buildings.m_buffer[(int)building], material, offerIn);
        }
        else if (active && offerIn.Building != 0)
        {
            Array16<Building> buildings2 = Singleton<BuildingManager>.instance.m_buildings;
            ushort building2 = offerIn.Building;
            BuildingInfo info4 = buildings2.m_buffer[(int)building2].Info;
            info4.m_buildingAI.StartTransfer(building2, ref buildings2.m_buffer[(int)building2], material, offerOut);
        }
    }
}