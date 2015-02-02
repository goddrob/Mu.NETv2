using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mu.NETv2.Models
{
    public class AccountContext : DbContext
    {
        public AccountContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<AccountCharacter> AccountCharacters { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<MEMB_STAT> Status { get; set; }
        public DbSet<GuildMember> GuildMembers { get; set; }
        public DbSet<Guild> Guilds { get; set; }
    }
    [Table("AccountCharacter")]
    public class AccountCharacter
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string GameID1 { get; set; }
        public string GameID2 { get; set; }
        public string GameID3 { get; set; }
        public string GameID4 { get; set; }
        public string GameID5 { get; set; }
        public string GameIDC { get; set; }

    }
    [Table("Character")]
    public class Character
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public string AccountID { get; set; }
        public int cLevel { get; set; }
        public int LevelUpPoint { get; set; }
        public Byte Class { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Energy { get; set; }
        public int Money { get; set; }
        public int Leadership { get; set; }
        public int Resets { get; set; }
        public int Experience { get; set; }
        public Int16 MapNumber { get; set; }
        public Int16 MapPosX { get; set; }
        public Int16 MapPosY { get; set; }
    }
    [Table("MEMB_STAT")]
    public class MEMB_STAT
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string memb___id { get; set; }
        public Byte ConnectStat { get; set; }
    }
    [Table("GuildMember")]
    public class GuildMember
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public string G_Name { get; set; }
    }
    [Table("Guild")]
    public class Guild
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public string G_Name { get; set; }
        public byte[] G_Mark { get; set; }
        public int G_Score { get; set; }
    }

    public class ResetModel
    {
        public string name {get;set;}
        public string errorMessage { get; set; }
    }

    
    
}