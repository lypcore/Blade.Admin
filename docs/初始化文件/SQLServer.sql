/*
 Navicat Premium Data Transfer

 Source Server         : MSSQL
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Host           : DESKTOP-MNHA820:1433
 Source Catalog        : Blade.Admin
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 16/09/2020 23:50:42
*/


-- ----------------------------
-- Table structure for BaseAction
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseAction]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseAction]
GO

CREATE TABLE [dbo].[BaseAction] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Deleted] bit DEFAULT ('false') NOT NULL,
  [ParentId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Type] int DEFAULT ((0)) NOT NULL,
  [Name] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Url] nvarchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [Value] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [NeedAction] bit DEFAULT ((0)) NOT NULL,
  [Icon] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Sort] int DEFAULT ((0)) NOT NULL
)
GO

ALTER TABLE [dbo].[BaseAction] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'否已删除',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'Deleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'父级Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'ParentId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'类型,菜单=0,页面=1,权限=2',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'Type'
GO

EXEC sp_addextendedproperty
'MS_Description', N'权限名/菜单名',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'Name'
GO

EXEC sp_addextendedproperty
'MS_Description', N'菜单地址',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'Url'
GO

EXEC sp_addextendedproperty
'MS_Description', N'权限值',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'Value'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否需要权限(仅页面有效)',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'NeedAction'
GO

EXEC sp_addextendedproperty
'MS_Description', N'图标',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'Icon'
GO

EXEC sp_addextendedproperty
'MS_Description', N'排序',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction',
'COLUMN', N'Sort'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统权限表',
'SCHEMA', N'dbo',
'TABLE', N'BaseAction'
GO


-- ----------------------------
-- Records of BaseAction
-- ----------------------------
INSERT INTO [dbo].[BaseAction]  VALUES (N'1178957405992521728', N'2019-10-01 16:58:44.000', NULL, N'0', NULL, N'0', N'系统管理', N'', NULL, N'1', N'setting', N'1')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1178957553778823168', N'2019-10-01 16:59:19.000', NULL, N'0', N'1178957405992521728', N'1', N'权限管理', N'/BaseManage/BaseAction/List', NULL, N'1', NULL, N'20')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1179018395304071168', N'2019-10-01 21:01:05.000', NULL, N'0', N'1178957405992521728', N'1', N'密钥管理', N'/BaseManage/BaseAppSecret/List', NULL, N'1', NULL, N'15')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1182652266117599232', N'2019-10-11 21:40:47.000', NULL, N'0', N'1178957405992521728', N'1', N'用户管理', N'/BaseManage/BaseUser/List', NULL, N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1182652367447789568', N'2019-10-11 21:41:11.000', NULL, N'0', N'1178957405992521728', N'1', N'角色管理', N'/BaseManage/BaseRole/List', NULL, N'1', NULL, N'5')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1182652433302556672', N'2019-10-11 21:41:27.000', NULL, N'0', N'1178957405992521728', N'1', N'部门管理', N'/BaseManage/BaseDepartment/List', NULL, N'1', NULL, N'10')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801057778569216', N'2019-10-28 20:53:53.687', NULL, N'0', N'1182652367447789568', N'2', N'增', NULL, N'BaseRole.Add', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801057778569217', N'2019-10-28 20:53:53.687', NULL, N'0', N'1182652367447789568', N'2', N'改', NULL, N'BaseRole.Edit', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801057778569218', N'2019-10-28 20:53:53.687', NULL, N'0', N'1182652367447789568', N'2', N'删', NULL, N'BaseRole.Delete', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801109783744512', N'2019-10-28 20:54:06.087', NULL, N'0', N'1182652433302556672', N'2', N'增', NULL, N'BaseDepartment.Add', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801109783744513', N'2019-10-28 20:54:06.087', NULL, N'0', N'1182652433302556672', N'2', N'改', NULL, N'BaseDepartment.Edit', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801109783744514', N'2019-10-28 20:54:06.087', NULL, N'0', N'1182652433302556672', N'2', N'删', NULL, N'BaseDepartment.Delete', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801273885888512', N'2019-10-28 20:54:45.213', NULL, N'0', N'1179018395304071168', N'2', N'增', NULL, N'BaseAppSecret.Add', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801273885888513', N'2019-10-28 20:54:45.213', NULL, N'0', N'1179018395304071168', N'2', N'改', NULL, N'BaseAppSecret.Edit', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801273885888514', N'2019-10-28 20:54:45.213', NULL, N'0', N'1179018395304071168', N'2', N'删', NULL, N'BaseAppSecret.Delete', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801341661646848', N'2019-10-28 20:55:01.370', NULL, N'0', N'1178957553778823168', N'2', N'增', NULL, N'BaseAction.Add', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801341661646849', N'2019-10-28 20:55:01.370', NULL, N'0', N'1178957553778823168', N'2', N'改', NULL, N'BaseAction.Edit', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1188801341661646850', N'2019-10-28 20:55:01.370', NULL, N'0', N'1178957553778823168', N'2', N'删', NULL, N'BaseAction.Delete', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1193158266167758848', N'2019-11-09 21:27:53.000', N'Admin', N'0', NULL, N'0', N'首页', NULL, NULL, N'1', N'home', N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1193158630615027712', N'2019-11-09 21:29:20.013', N'Admin', N'0', N'1193158266167758848', N'1', N'框架介绍', N'/Home/Introduce', NULL, N'0', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1193158780011941888', N'2019-11-09 21:29:55.630', N'Admin', N'0', N'1193158266167758848', N'1', N'运营统计', N'/Home/Statis', NULL, N'0', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1193527101521661952', N'2019-11-10 21:53:30.320', NULL, N'0', N'1182652266117599232', N'2', N'增', NULL, N'BaseUser.Add', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1193527101521661953', N'2019-11-10 21:53:30.320', NULL, N'0', N'1182652266117599232', N'2', N'改', NULL, N'BaseUser.Edit', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1193527101521661954', N'2019-11-10 21:53:30.320', NULL, N'0', N'1182652266117599232', N'2', N'删', NULL, N'BaseUser.Delete', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1248570020770877440', N'2020-04-10 19:14:24.000', N'Admin', N'0', N'1178957405992521728', N'1', N'操作日志', N'/BaseManage/BaseUserLog/List', NULL, N'0', NULL, N'22')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1304804237976276992', N'2020-09-12 23:29:07.083', N'Admin', N'0', N'1178957405992521728', N'1', N'读库管理', N'/BaseManage/BaseReadLibrary/List', NULL, N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1304804239708524544', N'2020-09-12 23:29:07.493', NULL, N'0', N'1304804237976276992', N'2', N'增', NULL, N'BaseReadLibrary.Add', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1304804239708524545', N'2020-09-12 23:29:07.493', NULL, N'0', N'1304804237976276992', N'2', N'改', NULL, N'BaseReadLibrary.Edit', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1304804239708524546', N'2020-09-12 23:29:07.493', NULL, N'0', N'1304804237976276992', N'2', N'删', NULL, N'BaseReadLibrary.Delete', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1305882999157428224', N'2020-09-15 22:55:43.790', N'Admin', N'0', N'1178957405992521728', N'1', N'定时任务', N'/BaseManage/BaseQuartzTask/List', NULL, N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1305883000965173248', N'2020-09-15 22:55:44.220', NULL, N'0', N'1305882999157428224', N'2', N'增', NULL, N'BaseQuartzTask.Add', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1305883000965173249', N'2020-09-15 22:55:44.220', NULL, N'0', N'1305882999157428224', N'2', N'改', NULL, N'BaseQuartzTask.Edit', N'1', NULL, N'0')
GO

INSERT INTO [dbo].[BaseAction]  VALUES (N'1305883000965173250', N'2020-09-15 22:55:44.220', NULL, N'0', N'1305882999157428224', N'2', N'删', NULL, N'BaseQuartzTask.Delete', N'1', NULL, N'0')
GO


-- ----------------------------
-- Table structure for BaseAppSecret
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseAppSecret]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseAppSecret]
GO

CREATE TABLE [dbo].[BaseAppSecret] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Deleted] bit DEFAULT ('false') NOT NULL,
  [AppId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [AppSecret] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [AppName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[BaseAppSecret] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'自然主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseAppSecret',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseAppSecret',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseAppSecret',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'否已删除',
'SCHEMA', N'dbo',
'TABLE', N'BaseAppSecret',
'COLUMN', N'Deleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'应用Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseAppSecret',
'COLUMN', N'AppId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'应用密钥',
'SCHEMA', N'dbo',
'TABLE', N'BaseAppSecret',
'COLUMN', N'AppSecret'
GO

EXEC sp_addextendedproperty
'MS_Description', N'应用名',
'SCHEMA', N'dbo',
'TABLE', N'BaseAppSecret',
'COLUMN', N'AppName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'应用密钥表',
'SCHEMA', N'dbo',
'TABLE', N'BaseAppSecret'
GO


-- ----------------------------
-- Records of BaseAppSecret
-- ----------------------------
INSERT INTO [dbo].[BaseAppSecret]  VALUES (N'1172497995938271232', N'2019-09-13 21:11:20.000', N'Admin', N'0', N'PcAdmin', N'wtMaiTRPTT3hrf5e', N'后台AppId')
GO

INSERT INTO [dbo].[BaseAppSecret]  VALUES (N'1173937877642383360', N'2019-09-17 20:32:55.000', N'Admin', N'0', N'AppAdmin', N'IVh9LLSVFcoQPQ5K', N'APP密钥')
GO


-- ----------------------------
-- Table structure for BaseBuildTest
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseBuildTest]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseBuildTest]
GO

CREATE TABLE [dbo].[BaseBuildTest] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Deleted] bit DEFAULT ('false') NOT NULL,
  [Column1] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Column2] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Column3] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Column4] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Column5] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[BaseBuildTest] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'自然主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'否已删除',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest',
'COLUMN', N'Deleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'列1',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest',
'COLUMN', N'Column1'
GO

EXEC sp_addextendedproperty
'MS_Description', N'列2',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest',
'COLUMN', N'Column2'
GO

EXEC sp_addextendedproperty
'MS_Description', N'列3',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest',
'COLUMN', N'Column3'
GO

EXEC sp_addextendedproperty
'MS_Description', N'列4',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest',
'COLUMN', N'Column4'
GO

EXEC sp_addextendedproperty
'MS_Description', N'列5',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest',
'COLUMN', N'Column5'
GO

EXEC sp_addextendedproperty
'MS_Description', N'生成测试表',
'SCHEMA', N'dbo',
'TABLE', N'BaseBuildTest'
GO


-- ----------------------------
-- Records of BaseBuildTest
-- ----------------------------
INSERT INTO [dbo].[BaseBuildTest]  VALUES (N'1251534328014311424', N'2020-04-18 23:33:30.000', N'Admin', N'0', N'asdas', N'sadsa', N'sad', N'sadsa', N'sadsad')
GO


-- ----------------------------
-- Table structure for BaseDbLink
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseDbLink]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseDbLink]
GO

CREATE TABLE [dbo].[BaseDbLink] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Deleted] bit DEFAULT ('false') NOT NULL,
  [LinkName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ConnectionStr] nvarchar(500) COLLATE Chinese_PRC_CI_AS  NULL,
  [DbType] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[BaseDbLink] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'自然主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseDbLink',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseDbLink',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseDbLink',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'否已删除',
'SCHEMA', N'dbo',
'TABLE', N'BaseDbLink',
'COLUMN', N'Deleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'连接名',
'SCHEMA', N'dbo',
'TABLE', N'BaseDbLink',
'COLUMN', N'LinkName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'连接字符串',
'SCHEMA', N'dbo',
'TABLE', N'BaseDbLink',
'COLUMN', N'ConnectionStr'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数据库类型',
'SCHEMA', N'dbo',
'TABLE', N'BaseDbLink',
'COLUMN', N'DbType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数据库连接表',
'SCHEMA', N'dbo',
'TABLE', N'BaseDbLink'
GO


-- ----------------------------
-- Records of BaseDbLink
-- ----------------------------
INSERT INTO [dbo].[BaseDbLink]  VALUES (N'1183373232498020352', N'2019-10-13 21:25:39.000', N'Admin', N'0', N'BaseDb', N'Data Source=.;Initial Catalog=Blade.Admin;Integrated Security=True', N'SqlServer')
GO


-- ----------------------------
-- Table structure for BaseDepartment
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseDepartment]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseDepartment]
GO

CREATE TABLE [dbo].[BaseDepartment] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Deleted] bit DEFAULT ('false') NOT NULL,
  [Name] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ParentId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[BaseDepartment] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseDepartment',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseDepartment',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseDepartment',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'否已删除',
'SCHEMA', N'dbo',
'TABLE', N'BaseDepartment',
'COLUMN', N'Deleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'部门名',
'SCHEMA', N'dbo',
'TABLE', N'BaseDepartment',
'COLUMN', N'Name'
GO

EXEC sp_addextendedproperty
'MS_Description', N'上级部门Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseDepartment',
'COLUMN', N'ParentId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'部门表',
'SCHEMA', N'dbo',
'TABLE', N'BaseDepartment'
GO


-- ----------------------------
-- Records of BaseDepartment
-- ----------------------------
INSERT INTO [dbo].[BaseDepartment]  VALUES (N'1181175685528424448', N'2019-10-07 19:53:23.000', NULL, N'0', N'宁波分公司', NULL)
GO

INSERT INTO [dbo].[BaseDepartment]  VALUES (N'1181175803631636480', N'2019-10-07 19:53:51.427', NULL, N'0', N'鄞州事业部', N'1181175685528424448')
GO

INSERT INTO [dbo].[BaseDepartment]  VALUES (N'1181175865409540096', N'2019-10-07 19:54:06.000', NULL, N'0', N'海曙事业部', N'1181175685528424448')
GO


-- ----------------------------
-- Table structure for BaseQuartzTask
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseQuartzTask]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseQuartzTask]
GO

CREATE TABLE [dbo].[BaseQuartzTask] (
  [Id] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [JobName] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [JobGroup] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [JobClassName] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [JobDescription] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [RunStatus] int  NOT NULL,
  [Enabled] tinyint  NOT NULL,
  [StarRunTime] datetime  NULL,
  [EndRunTime] datetime  NULL,
  [CronSecond] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CronMinute] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CronHour] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CronDay] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CronMonth] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CronWeek] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CronYear] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Message] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [SimpleTriggerRepeatCount] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SimpleTriggerRepeatSeconds] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ModifyTime] datetime  NULL
)
GO

ALTER TABLE [dbo].[BaseQuartzTask] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建者',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'任务名称',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'JobName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'任务所属分组',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'JobGroup'
GO

EXEC sp_addextendedproperty
'MS_Description', N'任务类名',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'JobClassName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'任务描述',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'JobDescription'
GO

EXEC sp_addextendedproperty
'MS_Description', N'运行状态 0：未运行 10：运行中 20：暂停',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'RunStatus'
GO

EXEC sp_addextendedproperty
'MS_Description', N'0：禁用 1：启用',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'Enabled'
GO

EXEC sp_addextendedproperty
'MS_Description', N'开始运行时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'StarRunTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'运行结束时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'EndRunTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'秒',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'CronSecond'
GO

EXEC sp_addextendedproperty
'MS_Description', N'分钟',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'CronMinute'
GO

EXEC sp_addextendedproperty
'MS_Description', N'小时',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'CronHour'
GO

EXEC sp_addextendedproperty
'MS_Description', N'日',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'CronDay'
GO

EXEC sp_addextendedproperty
'MS_Description', N'月',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'CronMonth'
GO

EXEC sp_addextendedproperty
'MS_Description', N'星期',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'CronWeek'
GO

EXEC sp_addextendedproperty
'MS_Description', N'年',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'CronYear'
GO

EXEC sp_addextendedproperty
'MS_Description', N'执行信息',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'Message'
GO

EXEC sp_addextendedproperty
'MS_Description', N'重复执行次数',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'SimpleTriggerRepeatCount'
GO

EXEC sp_addextendedproperty
'MS_Description', N'重复执行时间间隔',
'SCHEMA', N'dbo',
'TABLE', N'BaseQuartzTask',
'COLUMN', N'SimpleTriggerRepeatSeconds'
GO


-- ----------------------------
-- Records of BaseQuartzTask
-- ----------------------------
INSERT INTO [dbo].[BaseQuartzTask]  VALUES (N'1305787381139378176', N'2020-09-15 16:35:46.677', N'Admin', N' 测试定时任务', N' 测试定时任务1', N'Blade.Service.QuartzManage.QuartzTestJob', N'1', N'10', N'1', N'2020-09-09 00:00:00.000', N'2020-09-18 21:00:02.000', N'5', N'0', N'0', N'1', N'1', N'1', N'2020', N'', N'-1', N'1', N'2020-09-16 23:47:08.817')
GO


-- ----------------------------
-- Table structure for BaseReadLibrary
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseReadLibrary]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseReadLibrary]
GO

CREATE TABLE [dbo].[BaseReadLibrary] (
  [Id] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Des] varchar(500) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [HitRate] int  NOT NULL,
  [ConnectionString] varchar(500) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [IsEnable] int DEFAULT ((1)) NOT NULL,
  [ConnectionTotal] int DEFAULT ((0)) NOT NULL,
  [DbType] varchar(10) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[BaseReadLibrary] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'CreateTime',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'描述',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary',
'COLUMN', N'Des'
GO

EXEC sp_addextendedproperty
'MS_Description', N'HitRate',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary',
'COLUMN', N'HitRate'
GO

EXEC sp_addextendedproperty
'MS_Description', N'连接字符串',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary',
'COLUMN', N'ConnectionString'
GO

EXEC sp_addextendedproperty
'MS_Description', N'启用（0禁用，1启用）',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary',
'COLUMN', N'IsEnable'
GO

EXEC sp_addextendedproperty
'MS_Description', N'被链接次数',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary',
'COLUMN', N'ConnectionTotal'
GO

EXEC sp_addextendedproperty
'MS_Description', N'数据库类型',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary',
'COLUMN', N'DbType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'只读数据库表',
'SCHEMA', N'dbo',
'TABLE', N'BaseReadLibrary'
GO


-- ----------------------------
-- Records of BaseReadLibrary
-- ----------------------------
INSERT INTO [dbo].[BaseReadLibrary]  VALUES (N'1304804971174170624', N'2020-09-12 23:32:01.890', N'Admin', N'从库1', N'10', N'Data Source=.;Initial Catalog=Blade.Admin;Integrated Security=True;Pooling=true;', N'1', N'0', N'SqlServer')
GO

INSERT INTO [dbo].[BaseReadLibrary]  VALUES (N'1305507600820867072', N'2020-09-14 22:04:01.853', N'Admin', N'从库2', N'20', N'Data Source=.;Initial Catalog=Blade.Admin;Integrated Security=True;Pooling=true;', N'1', N'0', N'SqlServer')
GO


-- ----------------------------
-- Table structure for BaseRole
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseRole]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseRole]
GO

CREATE TABLE [dbo].[BaseRole] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Deleted] bit DEFAULT ('false') NOT NULL,
  [RoleName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[BaseRole] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseRole',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseRole',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseRole',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'否已删除',
'SCHEMA', N'dbo',
'TABLE', N'BaseRole',
'COLUMN', N'Deleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色名',
'SCHEMA', N'dbo',
'TABLE', N'BaseRole',
'COLUMN', N'RoleName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统角色表',
'SCHEMA', N'dbo',
'TABLE', N'BaseRole'
GO


-- ----------------------------
-- Records of BaseRole
-- ----------------------------
INSERT INTO [dbo].[BaseRole]  VALUES (N'1251144116734005248', N'2020-04-17 21:42:57.220', N'Admin', N'0', N'超级管理员')
GO

INSERT INTO [dbo].[BaseRole]  VALUES (N'1251145272742907904', N'2020-04-17 21:47:32.833', N'Admin', N'0', N'部门管理员')
GO


-- ----------------------------
-- Table structure for BaseRoleAction
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseRoleAction]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseRoleAction]
GO

CREATE TABLE [dbo].[BaseRoleAction] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Deleted] bit DEFAULT ('false') NOT NULL,
  [RoleId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ActionId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[BaseRoleAction] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseRoleAction',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseRoleAction',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseRoleAction',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'否已删除',
'SCHEMA', N'dbo',
'TABLE', N'BaseRoleAction',
'COLUMN', N'Deleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseRoleAction',
'COLUMN', N'RoleId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'权限Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseRoleAction',
'COLUMN', N'ActionId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色权限表',
'SCHEMA', N'dbo',
'TABLE', N'BaseRoleAction'
GO


-- ----------------------------
-- Records of BaseRoleAction
-- ----------------------------
INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801858282459136', N'2019-10-28 20:57:04.543', NULL, N'0', N'1180486275199668224', N'1182654049414025216')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801858282459137', N'2019-10-28 20:57:04.543', NULL, N'0', N'1180486275199668224', N'1182654208411701248')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801858282459138', N'2019-10-28 20:57:04.543', NULL, N'0', N'1180486275199668224', N'1183370665412005888')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540544', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188044797802188800')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540545', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188044797802188801')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540546', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1182652433302556672')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540547', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1178957405992521728')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540548', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188801109783744512')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540549', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188801109783744513')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540550', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188801109783744514')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540551', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1182652266117599232')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540552', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188800845714558976')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540553', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188800845714558977')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540554', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188800845714558978')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540555', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1182652367447789568')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540556', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188801057778569216')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540557', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188801057778569217')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1188801984434540558', N'2019-10-28 20:57:34.620', NULL, N'0', N'1180819481383931904', N'1188801057778569218')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1305012044734402560', N'2020-09-13 13:14:52.073', NULL, N'0', N'1251145272742907904', N'1193158266167758848')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1305012044738596864', N'2020-09-13 13:14:52.073', NULL, N'0', N'1251145272742907904', N'1193158630615027712')
GO

INSERT INTO [dbo].[BaseRoleAction]  VALUES (N'1305012044738596865', N'2020-09-13 13:14:52.073', NULL, N'0', N'1251145272742907904', N'1193158780011941888')
GO


-- ----------------------------
-- Table structure for BaseUser
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseUser]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseUser]
GO

CREATE TABLE [dbo].[BaseUser] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Deleted] bit DEFAULT ('false') NOT NULL,
  [UserName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Password] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [RealName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Sex] int DEFAULT ((0)) NOT NULL,
  [Birthday] date  NULL,
  [DepartmentId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[BaseUser] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'否已删除',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'Deleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户名',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'UserName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'密码',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'Password'
GO

EXEC sp_addextendedproperty
'MS_Description', N'姓名',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'RealName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'性别(1为男，0为女)',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'Sex'
GO

EXEC sp_addextendedproperty
'MS_Description', N'出生日期',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'Birthday'
GO

EXEC sp_addextendedproperty
'MS_Description', N'所属部门Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser',
'COLUMN', N'DepartmentId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统用户表',
'SCHEMA', N'dbo',
'TABLE', N'BaseUser'
GO


-- ----------------------------
-- Records of BaseUser
-- ----------------------------
INSERT INTO [dbo].[BaseUser]  VALUES (N'Admin', N'2019-09-13 21:10:03.000', N'Admin', N'0', N'Admin', N'e10adc3949ba59abbe56e057f20f883e', N'超级管理员', N'1', N'2019-09-13', N'1181175685528424448')
GO


-- ----------------------------
-- Table structure for BaseUserLog
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseUserLog]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseUserLog]
GO

CREATE TABLE [dbo].[BaseUserLog] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CreatorRealName] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [LogType] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [LogContent] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[BaseUserLog] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'自然主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserLog',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserLog',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserLog',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人姓名',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserLog',
'COLUMN', N'CreatorRealName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'日志类型',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserLog',
'COLUMN', N'LogType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'日志内容',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserLog',
'COLUMN', N'LogContent'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统日志表',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserLog'
GO


-- ----------------------------
-- Records of BaseUserLog
-- ----------------------------
INSERT INTO [dbo].[BaseUserLog]  VALUES (N'1304805376914362368', N'2020-09-12 23:33:38.627', N'Admin', N'超级管理员', N'部门管理', N'添加部门名:666')
GO

INSERT INTO [dbo].[BaseUserLog]  VALUES (N'1304808333571526656', N'2020-09-12 23:45:23.550', N'Admin', N'超级管理员', N'部门管理', N'删除部门名:666')
GO

INSERT INTO [dbo].[BaseUserLog]  VALUES (N'1305009973725499392', N'2020-09-13 13:06:38.307', N'Admin', N'超级管理员', N'系统用户管理', N'添加用户:测试一号')
GO

INSERT INTO [dbo].[BaseUserLog]  VALUES (N'1305011608048635904', N'2020-09-13 13:13:07.960', N'Admin', N'超级管理员', N'系统用户管理', N'修改用户:测试一号')
GO

INSERT INTO [dbo].[BaseUserLog]  VALUES (N'1305012044931534848', N'2020-09-13 13:14:52.120', N'Admin', N'超级管理员', N'系统角色管理', N'修改角色:部门管理员')
GO


-- ----------------------------
-- Table structure for BaseUserRole
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BaseUserRole]') AND type IN ('U'))
	DROP TABLE [dbo].[BaseUserRole]
GO

CREATE TABLE [dbo].[BaseUserRole] (
  [Id] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [CreateTime] datetime  NOT NULL,
  [CreatorId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Deleted] bit DEFAULT ('false') NOT NULL,
  [UserId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [RoleId] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[BaseUserRole] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'主键',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserRole',
'COLUMN', N'Id'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建时间',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserRole',
'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'创建人Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserRole',
'COLUMN', N'CreatorId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'否已删除',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserRole',
'COLUMN', N'Deleted'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserRole',
'COLUMN', N'UserId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色Id',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserRole',
'COLUMN', N'RoleId'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户角色表',
'SCHEMA', N'dbo',
'TABLE', N'BaseUserRole'
GO


-- ----------------------------
-- Records of BaseUserRole
-- ----------------------------
INSERT INTO [dbo].[BaseUserRole]  VALUES (N'1181927367719784448', N'2019-10-09 21:40:18.270', NULL, N'0', N'1181922344629702656', N'1180819481383931904')
GO

INSERT INTO [dbo].[BaseUserRole]  VALUES (N'1181927367719784449', N'2019-10-09 21:40:18.270', NULL, N'0', N'1181922344629702656', N'1180486275199668224')
GO

INSERT INTO [dbo].[BaseUserRole]  VALUES (N'1181927783786352640', N'2019-10-09 21:41:57.470', NULL, N'0', N'1181927783727632384', N'1180819481383931904')
GO

INSERT INTO [dbo].[BaseUserRole]  VALUES (N'1188802049190400000', N'2019-10-28 20:57:50.057', NULL, N'0', N'1181928860648738816', N'1180819481383931904')
GO

INSERT INTO [dbo].[BaseUserRole]  VALUES (N'1251386547933024256', N'2020-04-18 13:46:17.323', NULL, N'0', N'1251386547391959040', N'1251144116734005248')
GO

INSERT INTO [dbo].[BaseUserRole]  VALUES (N'1251423773970665472', N'2020-04-18 16:14:12.703', NULL, N'0', N'1251390402238353408', N'1251145272742907904')
GO

INSERT INTO [dbo].[BaseUserRole]  VALUES (N'1251423773970665473', N'2020-04-18 16:14:12.703', NULL, N'0', N'1251390402238353408', N'1251144116734005248')
GO

INSERT INTO [dbo].[BaseUserRole]  VALUES (N'1251518746514690048', N'2020-04-18 22:31:35.920', NULL, N'0', N'Admin', N'1251144116734005248')
GO

INSERT INTO [dbo].[BaseUserRole]  VALUES (N'1305011607763423232', N'2020-09-13 13:13:07.890', NULL, N'0', N'1305009972391710720', N'1251145272742907904')
GO


-- ----------------------------
-- Primary Key structure for table BaseAction
-- ----------------------------
ALTER TABLE [dbo].[BaseAction] ADD CONSTRAINT [PK__Base_Act__3214EC07F4E933AC] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseAppSecret
-- ----------------------------
ALTER TABLE [dbo].[BaseAppSecret] ADD CONSTRAINT [PK__Base_App__3214EC07B38FB32E] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseBuildTest
-- ----------------------------
ALTER TABLE [dbo].[BaseBuildTest] ADD CONSTRAINT [PK__Base_Bui__3214EC076CBE3601] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseDbLink
-- ----------------------------
ALTER TABLE [dbo].[BaseDbLink] ADD CONSTRAINT [PK__Base_DbL__3214EC07824BD5AE] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseDepartment
-- ----------------------------
ALTER TABLE [dbo].[BaseDepartment] ADD CONSTRAINT [PK__Base_Dep__3214EC07CF2BA38D] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseQuartzTask
-- ----------------------------
ALTER TABLE [dbo].[BaseQuartzTask] ADD CONSTRAINT [PK__BaseQuar__3214EC077582ED35] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseReadLibrary
-- ----------------------------
ALTER TABLE [dbo].[BaseReadLibrary] ADD CONSTRAINT [PK__BaseRead__3214EC07FF3DA5BC] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseRole
-- ----------------------------
ALTER TABLE [dbo].[BaseRole] ADD CONSTRAINT [PK__Base_Rol__3214EC07D47AB420] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseRoleAction
-- ----------------------------
ALTER TABLE [dbo].[BaseRoleAction] ADD CONSTRAINT [PK__Base_Rol__3214EC07DD65FF6D] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseUser
-- ----------------------------
ALTER TABLE [dbo].[BaseUser] ADD CONSTRAINT [PK__Base_Use__3214EC07389F2E55] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseUserLog
-- ----------------------------
ALTER TABLE [dbo].[BaseUserLog] ADD CONSTRAINT [PK__Base_Use__3214EC071137541A] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BaseUserRole
-- ----------------------------
ALTER TABLE [dbo].[BaseUserRole] ADD CONSTRAINT [PK__Base_Use__3214EC07DA188399] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

