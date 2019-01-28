

CREATE TABLE [dbo].[Events](
	[AggregateId] [uniqueidentifier] NOT NULL,
	[SequenceNumber] [int] NOT NULL,
	[Type] [varchar](1000) NOT NULL,
	[Body] [text] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[PollOrder] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY NONCLUSTERED 
(
	[AggregateId] ASC,
	[SequenceNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



/****** Object:  Index [IX_Events]    Script Date: 03/28/2014 17:46:09 ******/
CREATE CLUSTERED INDEX [IX_Events] ON [dbo].[Events] 
(
	[PollOrder] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Aggregates]    Script Date: 03/28/2014 17:41:48 ******/


CREATE TABLE [dbo].[Aggregates](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_Aggregates] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO