﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EmbyStat.Common;
using FluentMigrator;
using Microsoft.EntityFrameworkCore;

namespace EmbyStat.Repositories.Migrations
{
    [Migration(4)]
    class AlterDeviceTable : Migration
    {
        public override void Up()
        {
            Delete.Table(Constants.Tables.Devices);

            Create.Table(Constants.Tables.Devices)
                .WithColumn("Id").AsString().NotNullable().PrimaryKey("PK_Devices")
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("LastUserId").AsString().NotNullable()
                    .ForeignKey("FK_Devices_User_Id", Constants.Tables.User, "Id").OnDelete(Rule.Cascade)
                .WithColumn("AppName").AsString().NotNullable()
                .WithColumn("AppVersion").AsString().NotNullable()
                .WithColumn("IconUrl").AsString().Nullable()
                .WithColumn("DateLastActivity").AsDateTime().NotNullable();

            Create.Index("IX_Devices_UserId").OnTable(Constants.Tables.Devices).OnColumn("LastUserId");
        }

        public override void Down()
        {
            Delete.Table(Constants.Tables.Devices);

            Create.Table(Constants.Tables.Devices)
                .WithColumn("Id").AsString().NotNullable().PrimaryKey("PK_Devices")
                .WithColumn("AppName").AsString().Nullable()
                .WithColumn("AppVersion").AsString().Nullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("LastUserName").AsString().Nullable();
        }
    }
}