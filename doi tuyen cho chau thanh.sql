select * from mytv where user_name='tvh.cth.mys'


update ds_codinh set stt=(select top 1 stt from p where rtrim(p.acc)=ds_codinh.so_dt) where tuyen_tc='A1' and ma_huyen='CTH'
update gphone set stt=(select top 1 stt from p where rtrim(p.acc)=gphone.so_dt) where tuyen_tc='A1' and ma_huyen='CTH'
update mytv set stt=(select top 1 stt from p where rtrim(p.acc)=mytv.user_name) where tuyen_tc='A1' and ma_huyen='CTH'
update internet set stt=(select top 1 stt from p where rtrim(p.acc)=internet.user_name) where tuyen_tc='A1' and ma_huyen='CTH'


select * from p where left(acc,1)<>'3' and left(acc,7)<>'tvh.cth'




select * from internet where ma_huyen='CTH' order by tuyen_tc

select * from ds_codinh where ma_huyen='CTH' order by tuyen_tc



update mytv set tuyen_tc='A1' where user_name in (select rtrim(acc) from p)


select * from ds_codinh where so_dt in (select rtrim(acc) from p)

select * from gphone where so_dt in (select rtrim(acc) from p)

select * from internet where user_name in (select rtrim(acc) from p)


select * from mytv where user_name in (select rtrim(acc) from p)

select * into cd from ds_codinh


