--create trigger KıtapDurum
--on tblHareket
--after insert 
--as
--declare @Kitap int
--select @Kitap = Kitap from inserted
--update tblKitap set Durum=0 where Id=@Kitap

create trigger KitapDurum2
on tblHareket
after update
as
declare @Kitap int
select @Kitap=Kitap from inserted
update tblKitap set Durum=1 where Id=@Kitap