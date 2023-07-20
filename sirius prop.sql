alter procedure sel_eko_PlasmanDetay
@yil int,
@secim tinyint
as
begin

	select month(ep.tarih) ay,
	 case 
	 when kul.aciklama like 'TR-%' or kul.aciklama like 'GMS-YO%' then 'trakya' 
	 when kul.aciklama like 'T-%' then 'ticari' 
	 when kul.aciklama like 'K-%' then 'kobi' 
	 when kul.aciklama like 'SB-Konya%' then 'konya' 
	 when kul.aciklama like 'SB-OG%' then 'ankara' 
	 else kul.aciklama  
	 end sube 
	 ,sum(convert(decimal,bakiye)) risk  into #ayrinti  from eko_PazarlamaPerformansDetay ep 
	 left join(
	 select fd.firmano, tablo.adi,fd.temsilci,tablo.id,tablo.aciklama from firmadetay fd 
   inner join (select bc.bipaciklama aciklama,k.adi adi,k.id id from bipcodeparameters bc inner join  kullanici k on bc.bipekkod3 = k.id and k.aktif =1 where bipturu = 'DEPRT' and bc.bipaciklama <> 'Ýst-Beylikdüzü')
   tablo on fd.temsilci = tablo.id 
	 ) kul on kul.firmano = ep.firmaNo where year(ep.tarih) = @yil group by Month(ep.tarih),kul.aciklama order by ay

	 if(@secim =1)
		select ay,'toplam' sube ,sum(risk) risk from #ayrinti group by ay 
	 else if(@secim =2)
		select ay,sube,sum(risk) risk from #ayrinti where sube='ankara' group by ay , sube 
	 else if(@secim =3)
		select ay,sube,sum(risk) risk from #ayrinti where sube='konya' group by ay , sube 
	 else if(@secim =4)
		select ay,sube,sum(risk) risk from #ayrinti where sube='trakya' group by ay , sube 
	 else if(@secim =5)
		select ay,sube,sum(risk) risk from #ayrinti where sube='kobi' group by ay , sube 
	 else if(@secim =6)
		select ay,sube,sum(risk) risk from #ayrinti where sube='ticari' group by ay , sube 
		
	drop table #ayrinti

end

sel_eko_PlasmanDetay 2023,3
