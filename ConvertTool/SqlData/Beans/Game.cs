﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SqlData.Bases;

namespace SqlData.Beans
{
    public class Game:BeanBase
    {
        [Key]
        [Column("game_id")]
        public int GameId { set; get; }

        [Column("game_name")]
        public string GameName { set; get; }

        [Column("game_desc")]
        public string GameDesc { set; get; }

        [Column("play_total")]
        public int PlayTotal { set; get; }
    }
}