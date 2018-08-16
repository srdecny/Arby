# Historie a vývoj programu

Program měl původně scrapovat data z různých exchange portálů a hledat arbitráže. Naneštěstí, v době, kdy došlo na implementaci spoustu exchange portálů přestalo nabízet své služby občanům ČR, zejména proto, že tyto portály často sídlí v UK, takže Brexit dokonal své.

Jediný použitelný portál je momentálně jen Matchbook. V průběhu vývoje jsem zjistil, že některé části API jsou, stejně jako u většiny portálů, dostupné jen tehdy, pokud je uživatel přihlášen s účtem, který má nějaké finanční prostředky. U Matchbooku je ta částka asi 100 liber, u ostatních nevím.

Zkoumal jsem, jestli jediné dvě použitelné české sázkové kanceláře mají nějaké API. Tisport mi na email ani neodpověděl a Fortuna prohlásila, že žádné takové informace neposkytují. Když jsem ke konci implementace programu zjistil, že jak Fortuna, tak Tisport nabízejí XML feed, bylo to sice příjemné zjištění, ale přišlo poněkud pozdě. Z tohoto důvodu není modul, zpracovávájící XML feed Fortuny navržen optimálně, jelikož to byla poslední věc, co se implementovala.

V průběhu vývoje jsem také udělal fatální chybu - při hledání inspirace pro funkcionality programu jsem narazil na profesionální software, který dělá přesně to, co jsem chtěl zamýšlet já a navíc mnoho dalšího. Velká část mé motivace se rázem vypařila.

Program také nikdy nebyl zamýšlen jako něco pro reálné použití. Arbitráže, ačkoliv vzácné, existují, nicméně procento zisku vzhledem k použitému kapitálu dosahuje nízkých jednotek procent. Bohužel, už po jedné provedené arbitráži sázkové kanceláře rády limitují či rovnou zavírají účty, takže bez stálého přísunu nových identit se nejedná o lukrativní byznys. Navíc se kurzy mění velice rychle a XML feed Fortuny rozhodně není real-time.

# Popis programu

## Použité technologie + architektura

Program je dělaný jako WinForms aplikace, která se seskládá z jednoho hlavního formuláře `ArbyForm` a několika podformulářů, kterými se ovládají jednotlivé komponenty. Rozhodnutí použít WinForms bylo špatné. Z domácích úkolů jsem nabyl dojmu, že se bude pro mé účely jednat o dobrou a pohodlnou volbu. Podcenil jsem absenci hlubší znalosti frameworku a jeho částečnou zastaralost, což se v kódu projevilo na mnoha místech. Je také použit návrhový model MVC, nicméně ne vždy se ho podařilo dodržet, hlavně díky nejasné hranici abstrakce mezi formuláři a Controllerem.

Záměrně nebyla použita in-memory databáze pro zjednodušení implementace a místo toho ji supluje `MatchbookModel`, který v sobě obsahuje data, povětšinou v polích, nebo slovnících. Toto nebylo dobré rozhodnutí. Nyní bych rozhodně databázi použil. Na serializaci/deserializaci .jsonů je použita knihovna od Newtonsoftu. Pro zpracovávání API byl použita knihovna s webklientem od Microsoftu a v jednom případě, kde jsem chtěl mít `datagridview` element, který by umožňoval automatické třídění záznamů, byla použita knihovna `UnofficialBindingListView`.

## Popis některých formulářů

### ArbyForm

Hlavní formulář, obsahující v sobě `MatchbookController`, který se stará převážně o komunikaci s Matchbookem a `MatchbookModel`, což je datová třída, obsahující data o jednotlivých sázkách a zápasech. Obsahuje také obsluhu scraperu, který pravidelně získává data o vybraných zápasech. Část funkcí, starajících se o vykreslování GUI je oddělena do `FormGUI`.

Scraper pravidelně posílá requesty na API Matchbooku a získaná data ukládá do modelu. Jsou zpracovávány jen trhy na přímou výhru, ostatní, jako třeba skóre v poločasu a podobně nejsou. To je zejména protože tyto trhy jsou na Matchbooku obchodovány minimálně i u populárních akcí a u méně populárních v podstatě vůbec. Získaná data jsou ukládána jako instance interní datové třídy `MarketSnapshot`.

Není implementované vyhledávání jednotlivých eventů, protože API žádnou takovou službu neposkytuje. Jediná možnost, jak získat inforamce o eventu bez znalosti jeho ID je služba, která vrátí "populární eventy", což jsou ty, které jsou momentálně zobrazené na hlavní stránce matchbooku a jsou také nejvíce obchodované. 

### SettingsManager

Pro získání existujících nastavení z `SettingsData` a ukládání nových hodnot je použita reflection. Jednalo se spíše o edukativní použití této technologie, rozhodně se nejedná o nejlepší možnost implementace.


## Ostatní soubory

V adresáři `dataclass` se nachází všechny důležité datové třídy, některé pro deserializaci získaných dat, jako `FortunaXML` a `MatchbookEvent`. Ostatní jsou interní datové třídy, jako `MarketSnapshot`. V některých souborech jsou také statické helper metody, které s danými daty pracují.

V `util` adresáři jsou všelijaké utility, od vlastních Timerů, po nové ovládácí prvky formuláře, až po serializér a konverter mezi interními datovými třídami.



