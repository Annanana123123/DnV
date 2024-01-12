using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DnV.Models;
using System.Windows;

namespace DnV
{
    public class Processor
    {
        private static string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\genii\source\repos\DnV\DnV\Database.mdf;Integrated Security=True";
        private const int timeOut = 100;

        public static void SetNPCInRoom(BattleModel person)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();

                    param.Add("@Id", person.Id);
                    param.Add("@Name", person.Name);
                    param.Add("@Imag", person.Imag);
                    param.Add("@Note", person.Note);
                    param.Add("@Defence", person.Defence);
                    param.Add("@Health", person.Health);
                    param.Add("@RoomId", person.RoomId);
                    param.Add("@NPCId", person.NPCId);
                    param.Add("@HistoryText", person.HistoryText);

                    connection.Query(SqlStr.SetNPCInRoom, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SetPerson(BattleModel person)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();

                    //HistoryId
                    //Name
                    //NameUser
                    //Imag
                    //Species
                    //Class
                    //Note
                    //Defence 
                    //Health
                    //Power
                    //PowerMod
                    //PowerSave
                    //Dexterity
                    //DexterityMod
                    //DexteritySave
                    //Endurance
                    //EnduranceMod
                    //EnduranceSave
                    //Intelligence
                    //IntelligenceMod
                    //IntelligenceSave
                    //Wisdom
                    //WisdomMod
                    //WisdomSave
                    //Charisma
                    //CharismaMod
                    //CharismaSave
                    //PassivWisdom
                    //SkillBonus
                    //Acrobatics
                    //Analysis
                    //Athletics
                    //Perception
                    //Survival
                    //Performance
                    //Intimidation
                    //History
                    //SleightOfHand
                    //Magic
                    //Medicine
                    //Deception
                    //Nature
                    //Insight
                    //Religion
                    //Stealth
                    //Persuasion
                    //AnimalCare
                    //IsNPC

                    param.Add("@Id", person.Id);
                    param.Add("@HistoryId", person.HistoryId);
                    param.Add("@Name", person.Name);
                    param.Add("@NameUser", person.NameUser);
                    param.Add("@Imag", person.Imag);
                    param.Add("@Species", person.Species);
                    param.Add("@Class", person.ClassPerson);
                    param.Add("@Note", person.Note);
                    param.Add("@Defence", person.Defence);
                    param.Add("@Health", person.Health);
                    param.Add("@Power", person.Power);
                    param.Add("@PowerMod", person.PowerMod);
                    param.Add("@PowerSave", person.PowerSave);
                    param.Add("@Dexterity", person.Dexterity);
                    param.Add("@DexterityMod", person.DexterityMod);
                    param.Add("@DexteritySave", person.DexteritySave);
                    param.Add("@Endurance", person.Endurance);
                    param.Add("@EnduranceMod", person.EnduranceMod);
                    param.Add("@EnduranceSave", person.EnduranceSave);
                    param.Add("@Intelligence", person.Intelligence);
                    param.Add("@IntelligenceMod", person.IntelligenceMod);
                    param.Add("@IntelligenceSave", person.IntelligenceSave);
                    param.Add("@Wisdom", person.Wisdom);
                    param.Add("@WisdomMod", person.WisdomMod);
                    param.Add("@WisdomSave", person.WisdomSave);
                    param.Add("@Charisma", person.Charisma);
                    param.Add("@CharismaMod", person.CharismaMod);
                    param.Add("@CharismaSave", person.CharismaSave);
                    param.Add("@PassivWisdom", person.PassivWisdom);
                    param.Add("@SkillBonus", person.SkillBonus);
                    param.Add("@Acrobatics", person.Acrobatics);
                    param.Add("@Analysis", person.Analysis);
                    param.Add("@Analysis", person.Analysis);
                    param.Add("@Athletics", person.Athletics);
                    param.Add("@Perception", person.Perception);
                    param.Add("@Survival", person.Survival);
                    param.Add("@Performance", person.Performance);
                    param.Add("@Intimidation", person.Intimidation);
                    param.Add("@History", person.History);
                    param.Add("@SleightOfHand", person.SleightOfHand);
                    param.Add("@Magic", person.Magic);
                    param.Add("@Medicine", person.Medicine);
                    param.Add("@Deception", person.Deception);
                    param.Add("@Nature", person.Nature);
                    param.Add("@Insight", person.Insight);
                    param.Add("@Religion", person.Religion);
                    param.Add("@Stealth", person.Stealth);
                    param.Add("@Persuasion", person.Persuasion);
                    param.Add("@AnimalCare", person.AnimalCare);
                    param.Add("@Attack", person.Attack);
                    param.Add("@IsNPC", person.IsNPC);

                    connection.Query(SqlStr.SetPerson, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SetEvent(string name, int order, int roomId, string sound, string imag, string text, int id = 0)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();

                    //result = connection.Query<HistoryModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: 100).ToList();
                    if (id == 0)
                    {
                        param.Add("@name", name);
                        param.Add("@order", order);
                        param.Add("@roomId", roomId);
                        param.Add("@sound", sound);
                        param.Add("@text", text);
                        param.Add("@imag", imag);
                    }
                    else
                    {
                        param.Add("@id", id);
                        param.Add("@name", name);
                        param.Add("@order", order);
                        param.Add("@roomId", roomId);
                        param.Add("@sound", sound);
                        param.Add("@text", text);
                        param.Add("@imag", imag); ;
                    }
                    connection.Query(SqlStr.SetEventSaveEdit, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SetRoom(string name, int order, int historyId, string sound, string imag, string text, int id = 0)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    
                    //result = connection.Query<HistoryModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: 100).ToList();
                    if (id == 0)
                    {
                        param.Add("@name", name);
                        param.Add("@order", order);
                        param.Add("@historyId", historyId);
                        param.Add("@sound", sound);
                        param.Add("@text", text);
                        param.Add("@imag", imag);
                    }
                    else
                    {
                        param.Add("@id", id);
                        param.Add("@name", name);
                        param.Add("@order", order);
                        param.Add("@historyId", historyId);
                        param.Add("@sound", sound);
                        param.Add("@text", text);
                        param.Add("@imag", imag); ;
                    }
                    connection.Query(SqlStr.SetRoomSaveEdit, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SetHistory(int id, string name, int visibility, string imag, int save)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id", id);
                    param.Add("@name", name);
                    param.Add("@visibility", visibility);
                    param.Add("@imag", imag);
                    //result = connection.Query<HistoryModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: 100).ToList();
                    if (save == 0)
                    {
                        connection.Query(SqlStr.SetHistory, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                    }
                    else
                    {
                        connection.Query(SqlStr.SetHistorySave, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static List<NPCComboBoxModel> GetNPCComboBox()
        {
            List<NPCComboBoxModel> result = new List<NPCComboBoxModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    result = connection.Query<NPCComboBoxModel>(SqlStr.GetNPCComboBox, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static List<ListModel> GetStatus()
        {
            List<ListModel> result = new List<ListModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    //DynamicParameters param = new DynamicParameters();
                    //param.Add("@id", id);
                    //result = connection.Query<HistoryModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: 100).ToList();
                    result = connection.Query<ListModel>(SqlStr.GetStatus, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static List<HistoryModel> GetHistory(int num)
        {
            List<HistoryModel> result = new List<HistoryModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@visibility", num);
                    //result = connection.Query<HistoryModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: 100).ToList();
                    result = connection.Query<HistoryModel>(SqlStr.GetHistory, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static List<RoomModel> GetRoom(int historyId)
        {
            List<RoomModel> result = new List<RoomModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@historyId", historyId);
                    //result = connection.Query<HistoryModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: 100).ToList();
                    result = connection.Query<RoomModel>(SqlStr.GetRoom, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static List<EventModel> GetEvent(int historyId)
        {
            List<EventModel> result = new List<EventModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@historyId", historyId);
                    //result = connection.Query<HistoryModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: 100).ToList();
                    result = connection.Query<EventModel>(SqlStr.GetEvent, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static List<BattleModel> GetNPCEditor()
        {
            List<BattleModel> result = new List<BattleModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();

                    //result = connection.Query<HistoryModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: 100).ToList();
                    result = connection.Query<BattleModel>(SqlStr.GetNPCEditor, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static List<BattleModel> GetNPC(int historyId)
        {
            List<BattleModel> result = new List<BattleModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@historyId", historyId);
                    //result = connection.Query<HistoryModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: 100).ToList();
                    result = connection.Query<BattleModel>(SqlStr.GetNPC, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static List<BattleModel> GetBattlePerson(int historyId)
        {
            List<BattleModel> result = new List<BattleModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@historyId", historyId);
                    result = connection.Query<BattleModel>(SqlStr.GetBattlePerson, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        public static List<BattleModel> GetHero(int? historyId = null)
        {
            List<BattleModel> result = new List<BattleModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    if (historyId is null)
                    {
                        param.Add("@historyId", 0);
                    }
                    else
                    {
                        param.Add("@historyId", historyId);
                    }
                    
                    result = connection.Query<BattleModel>(SqlStr.GetHero, param, commandType: CommandType.StoredProcedure, commandTimeout: timeOut).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
    }
}
