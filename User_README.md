# Disclaimer

Zápočtový program pro `NPRG035` a `NPRG038`, 2017/2018, Vojtěch Srdečný.

# Základní pojmy ohledně sázení

Ve světě (sportovního) sázení se nejvíce můžeme setkat s tradičními sázkovými kancelářemi jako je Fortuna, Tisport a další, které nabízejí možnost vsadit si na určitý výsledek. Tomuto typu sázení, kdy se sází na to, že se nějaká událost `stane`, se říká `back` sázka. Existují i `exchange` kanceláře, jako například Matchbook, které nabízejí i možnost vsadit si na to, že nějaká událost `nenastane`. Této sázce se říká `lay` sázka a jedná se o formu "zastoupení" klasické sázkové kanceláře - lze na to nahlížet tak, že lay sázkou se přijme něčí back sázka. Z toho vyplývá, že součástí `lay` sázky je i částka `accountability`, což je vlastně potenciální výhra odpovídající back sázky.

Zajímavé pozorování je, že pokud se nám podaří na nějakou událost najít back odds, které budou vyšší než lay odds, máme zajištěn profit. Viz kalkulačka: https://www.oddsmonkey.com/tools/calculator.aspx. (Bet type: normal). K těmto `arbitrážím` ale dochází poměrně zřídka.

# Popis programu

Program `Arby` je formulářová aplikace, umožňující automatické získávání dat o jednotlivých zápasech z exchange kanceláře Matchbook, jejich následné ukládání a prohlížení historie vývoje cen v grafech. Program také umožňuje zobrazovat XML feed nabízený sázkovou kanceláří Fortuna a hlídat arbitráže.

Arbitráže a obecně data pracují pouze s `outright` sázkami, tedy na konečný výsledek zápasu a nikoliv na ostatní trhy typu "skóre o poločasu" atp. Důvodem je zjednodušení a to, že krom outright sázek se na Matchbooku prakticky nic jiného nesází.

Program se skládá z jednoho hlavního formuláře, který je dostupný po spuštění aplikace a několika modulů, které rozšiřují funkcionalitu hlavního programu.

## Hlavní formulář

V tomto formuláři lze tlačítkem `Get popular events` získat aktuální populární zápasy na Matchbooku a `Get market prices` zobrazí detailní výpis nabídek pro daný zápas. Po vybrání eventu v nabídce ho lze tlačítky `Add/remove from scraper` přidávat/odebírat do scraperu, který bude pravidelně získávat aktuální data o daném eventu a ukládat je do databáze. `Refresh scraper info` pak zobrazí počet získaných snapshotů z daného zápasu. Lze se také přihlásit do Matchbooku.

## Snapshot manager

V tomto modulu lze upravovat záznamy databáze. Do levého okna lze importovat/exportova záznamy z `.json` souborů. Do pravého okna pak lze tlačítkem `Import application database` nahrát současný obsah databáze. Tlačítky uprostřed lze přesouvat a mazat jednotlivé záznamy. Po stisknutí tlačítka `exit` se současný obsah databáze nahradí obsahem pravého okna.

## Snapshot visualizer

V tomto modulu lze zobrazit historii vývoje cen zápasů v databázi po aplikování filtrů v dropdown boxech.

## Settings 

V tomto modulu lze nastavit některá nastavení. V současnosti je to login/password do matchbooku a interval mezi jednotlivým scrapováním hlídaných eventů. Nastavení je potřeba uložit tlačítkem `Save`.

## Fortuna XML feed

V tomto modulu lze zobrazovat informace o právě nabízených zápasech od Fortuny. XML feed má zpoždění několik desítek sekund. Nalezené zápasy lze filtrovat přes vyhledávání podle jména zápasu. Po vybrání řádky se zápasem Fortuny a sledovaného eventu v Matchbooku lze nastavit sledování arbitráží.

# Zkušební data

Ve stejné složce, jako je tato dokumentace, je soubor `testing_data.json`, který obsahuje cca osm hodin snapshotů jednoho zápasu. Jinak je možné si pomocí scraperu vyrobit vlastní testovací data.