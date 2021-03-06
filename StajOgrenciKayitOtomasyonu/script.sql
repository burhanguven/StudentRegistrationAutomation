USE [ogrenciKayitOTO]
GO
/****** Object:  Table [dbo].[kullaniciGiris]    Script Date: 8.5.2018 12:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kullaniciGiris](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kullaniciAdi] [varchar](50) NULL,
	[sifre] [varchar](15) NULL,
 CONSTRAINT [PK_kullaniciGiris] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ogrenciBilgii]    Script Date: 8.5.2018 12:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ogrenciBilgii](
	[tcNo] [nchar](11) NULL,
	[adSoyad] [varchar](50) NULL,
	[okul] [varchar](50) NULL,
	[bolum] [varchar](50) NULL,
	[sinif] [varchar](50) NULL,
	[baslangicT] [varchar](50) NULL,
	[bitisT] [varchar](50) NULL,
	[fotograf] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[kullaniciGiris] ON 

INSERT [dbo].[kullaniciGiris] ([id], [kullaniciAdi], [sifre]) VALUES (1, N'burhan', N'123456789')
INSERT [dbo].[kullaniciGiris] ([id], [kullaniciAdi], [sifre]) VALUES (2, N'can', N'1')
INSERT [dbo].[kullaniciGiris] ([id], [kullaniciAdi], [sifre]) VALUES (3, N'a', N'1')
INSERT [dbo].[kullaniciGiris] ([id], [kullaniciAdi], [sifre]) VALUES (4, N'wolverine', N'1')
INSERT [dbo].[kullaniciGiris] ([id], [kullaniciAdi], [sifre]) VALUES (6, N'asdasas', N'123123123')
SET IDENTITY_INSERT [dbo].[kullaniciGiris] OFF
INSERT [dbo].[ogrenciBilgii] ([tcNo], [adSoyad], [okul], [bolum], [sinif], [baslangicT], [bitisT], [fotograf]) VALUES (N'22222      ', N'aaa', N'aaa', N'aaaa', N'System.Windows.Forms.ComboBox, Items.Count: 4', N'1212', N'1221', N'')
INSERT [dbo].[ogrenciBilgii] ([tcNo], [adSoyad], [okul], [bolum], [sinif], [baslangicT], [bitisT], [fotograf]) VALUES (N'122121     ', N'qwqwq', N'qwqwq', N'qwqw', N'System.Windows.Forms.ComboBox, Items.Count: 4', N'121221', N'211212', N'')
