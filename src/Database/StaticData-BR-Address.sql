if not exists(select * from Core_Country where id = 'BR')
begin 
	insert into Core_Country (Id,Name,Code3,IsBillingEnabled,IsShippingEnabled,IsCityEnabled,IsZipCodeEnabled,IsDistrictEnabled)
	select 'BR','Brasil','BRA',	1,	1,	0,	1,	1
end


select *
into #tmpEstados
from (

	select 'Acre' as Estado, 'AC' as sigla union all
	select 'Alagoas' as Estado, 'AL' as sigla union all
	select 'Amapá' as Estado, 'AP' as sigla union all
	select 'Amazonas' as Estado, 'AM' as sigla union all
	select 'Bahia' as Estado, 'BA' as sigla union all
	select 'Ceará' as Estado, 'CE' as sigla union all
	select 'Distrito Federal' as Estado, 'DF' as sigla union all
	select 'Espírito Santo' as Estado, 'ES' as sigla union all
	select 'Goiás' as Estado, 'GO' as sigla union all
	select 'Maranhão' as Estado, 'MA' as sigla union all
	select 'Mato Grosso' as Estado, 'MT' as sigla union all
	select 'Mato Grosso do Sul' as Estado, 'MS' as sigla union all
	select 'Minas Gerais' as Estado, 'MG' as sigla union all
	select 'Pará' as Estado, 'PA' as sigla union all
	select 'Paraíba' as Estado, 'PB' as sigla union all
	select 'Paraná' as Estado, 'PR' as sigla union all
	select 'Pernambuco' as Estado, 'PE' as sigla union all
	select 'Piauí' as Estado, 'PI' as sigla union all
	select 'Rio de Janeiro' as Estado, 'RJ' as sigla union all
	select 'Rio Grande do Norte' as Estado, 'RN' as sigla union all
	select 'Rio Grande do Sul' as Estado, 'RS' as sigla union all
	select 'Rondônia' as Estado, 'RO' as sigla union all
	select 'Roraima' as Estado, 'RR' as sigla union all
	select 'Santa Catarina' as Estado, 'SC' as sigla union all
	select 'São Paulo' as Estado, 'SP' as sigla union all
	select 'Sergipe' as Estado, 'SE' as sigla union all
	select 'Tocantins' as Estado, 'TO' as sigla 
) as t

insert into Core_StateOrProvince (CountryId,Code,Name,Type)
select 'BR',Sigla,Estado,'Estado'
from #tmpEstados as tmp
left join Core_StateOrProvince as s
	on s.Code = tmp.sigla
	and s.Name = tmp.Estado
	and s.CountryId = 'BR'
where s.id is null
order by estado


select *
into #tmpCidades
from (
	select 'RO' as Estado, 'Alta Floresta D''Oeste' as Municipio union all
	select 'RO' as Estado, 'Alto Alegre dos Parecis' as Municipio union all
	select 'RO' as Estado, 'Alto Paraíso' as Municipio union all
	select 'RO' as Estado, 'Alvorada D''Oeste' as Municipio union all
	select 'RO' as Estado, 'Ariquemes' as Municipio union all
	select 'RO' as Estado, 'Buritis' as Municipio union all
	select 'RO' as Estado, 'Cabixi' as Municipio union all
	select 'RO' as Estado, 'Cacaulândia' as Municipio union all
	select 'RO' as Estado, 'Cacoal' as Municipio union all
	select 'RO' as Estado, 'Campo Novo de Rondônia' as Municipio union all
	select 'RO' as Estado, 'Candeias do Jamari' as Municipio union all
	select 'RO' as Estado, 'Castanheiras' as Municipio union all
	select 'RO' as Estado, 'Cerejeiras' as Municipio union all
	select 'RO' as Estado, 'Chupinguaia' as Municipio union all
	select 'RO' as Estado, 'Colorado do Oeste' as Municipio union all
	select 'RO' as Estado, 'Corumbiara' as Municipio union all
	select 'RO' as Estado, 'Costa Marques' as Municipio union all
	select 'RO' as Estado, 'Cujubim' as Municipio union all
	select 'RO' as Estado, 'Espigão D''Oeste' as Municipio union all
	select 'RO' as Estado, 'Governador Jorge Teixeira' as Municipio union all
	select 'RO' as Estado, 'Guajará-Mirim' as Municipio union all
	select 'RO' as Estado, 'Itapuã do Oeste' as Municipio union all
	select 'RO' as Estado, 'Jaru' as Municipio union all
	select 'RO' as Estado, 'Ji-Paraná' as Municipio union all
	select 'RO' as Estado, 'Machadinho D''Oeste' as Municipio union all
	select 'RO' as Estado, 'Ministro Andreazza' as Municipio union all
	select 'RO' as Estado, 'Mirante da Serra' as Municipio union all
	select 'RO' as Estado, 'Monte Negro' as Municipio union all
	select 'RO' as Estado, 'Nova Brasilândia D''Oeste' as Municipio union all
	select 'RO' as Estado, 'Nova Mamoré' as Municipio union all
	select 'RO' as Estado, 'Nova União' as Municipio union all
	select 'RO' as Estado, 'Novo Horizonte do Oeste' as Municipio union all
	select 'RO' as Estado, 'Ouro Preto do Oeste' as Municipio union all
	select 'RO' as Estado, 'Parecis' as Municipio union all
	select 'RO' as Estado, 'Pimenta Bueno' as Municipio union all
	select 'RO' as Estado, 'Pimenteiras do Oeste' as Municipio union all
	select 'RO' as Estado, 'Porto Velho' as Municipio union all
	select 'RO' as Estado, 'Presidente Médici' as Municipio union all
	select 'RO' as Estado, 'Primavera de Rondônia' as Municipio union all
	select 'RO' as Estado, 'Rio Crespo' as Municipio union all
	select 'RO' as Estado, 'Rolim de Moura' as Municipio union all
	select 'RO' as Estado, 'Santa Luzia D''Oeste' as Municipio union all
	select 'RO' as Estado, 'São Felipe D''Oeste' as Municipio union all
	select 'RO' as Estado, 'São Francisco do Guaporé' as Municipio union all
	select 'RO' as Estado, 'São Miguel do Guaporé' as Municipio union all
	select 'RO' as Estado, 'Seringueiras' as Municipio union all
	select 'RO' as Estado, 'Teixeirópolis' as Municipio union all
	select 'RO' as Estado, 'Theobroma' as Municipio union all
	select 'RO' as Estado, 'Urupá' as Municipio union all
	select 'RO' as Estado, 'Vale do Anari' as Municipio union all
	select 'RO' as Estado, 'Vale do Paraíso' as Municipio union all
	select 'RO' as Estado, 'Vilhena' as Municipio union all
	select 'AC' as Estado, 'Acrelândia' as Municipio union all
	select 'AC' as Estado, 'Assis Brasil' as Municipio union all
	select 'AC' as Estado, 'Brasiléia' as Municipio union all
	select 'AC' as Estado, 'Bujari' as Municipio union all
	select 'AC' as Estado, 'Capixaba' as Municipio union all
	select 'AC' as Estado, 'Cruzeiro do Sul' as Municipio union all
	select 'AC' as Estado, 'Epitaciolândia' as Municipio union all
	select 'AC' as Estado, 'Feijó' as Municipio union all
	select 'AC' as Estado, 'Jordão' as Municipio union all
	select 'AC' as Estado, 'Mâncio Lima' as Municipio union all
	select 'AC' as Estado, 'Manoel Urbano' as Municipio union all
	select 'AC' as Estado, 'Marechal Thaumaturgo' as Municipio union all
	select 'AC' as Estado, 'Plácido de Castro' as Municipio union all
	select 'AC' as Estado, 'Porto Acre' as Municipio union all
	select 'AC' as Estado, 'Porto Walter' as Municipio union all
	select 'AC' as Estado, 'Rio Branco' as Municipio union all
	select 'AC' as Estado, 'Rodrigues Alves' as Municipio union all
	select 'AC' as Estado, 'Santa Rosa do Purus' as Municipio union all
	select 'AC' as Estado, 'Sena Madureira' as Municipio union all
	select 'AC' as Estado, 'Senador Guiomard' as Municipio union all
	select 'AC' as Estado, 'Tarauacá' as Municipio union all
	select 'AC' as Estado, 'Xapuri' as Municipio union all
	select 'AM' as Estado, 'Alvarães' as Municipio union all
	select 'AM' as Estado, 'Amaturá' as Municipio union all
	select 'AM' as Estado, 'Anamã' as Municipio union all
	select 'AM' as Estado, 'Anori' as Municipio union all
	select 'AM' as Estado, 'Apuí' as Municipio union all
	select 'AM' as Estado, 'Atalaia do Norte' as Municipio union all
	select 'AM' as Estado, 'Autazes' as Municipio union all
	select 'AM' as Estado, 'Barcelos' as Municipio union all
	select 'AM' as Estado, 'Barreirinha' as Municipio union all
	select 'AM' as Estado, 'Benjamin Constant' as Municipio union all
	select 'AM' as Estado, 'Beruri' as Municipio union all
	select 'AM' as Estado, 'Boa Vista do Ramos' as Municipio union all
	select 'AM' as Estado, 'Boca do Acre' as Municipio union all
	select 'AM' as Estado, 'Borba' as Municipio union all
	select 'AM' as Estado, 'Caapiranga' as Municipio union all
	select 'AM' as Estado, 'Canutama' as Municipio union all
	select 'AM' as Estado, 'Carauari' as Municipio union all
	select 'AM' as Estado, 'Careiro' as Municipio union all
	select 'AM' as Estado, 'Careiro da Várzea' as Municipio union all
	select 'AM' as Estado, 'Coari' as Municipio union all
	select 'AM' as Estado, 'Codajás' as Municipio union all
	select 'AM' as Estado, 'Eirunepé' as Municipio union all
	select 'AM' as Estado, 'Envira' as Municipio union all
	select 'AM' as Estado, 'Fonte Boa' as Municipio union all
	select 'AM' as Estado, 'Guajará' as Municipio union all
	select 'AM' as Estado, 'Humaitá' as Municipio union all
	select 'AM' as Estado, 'Ipixuna' as Municipio union all
	select 'AM' as Estado, 'Iranduba' as Municipio union all
	select 'AM' as Estado, 'Itacoatiara' as Municipio union all
	select 'AM' as Estado, 'Itamarati' as Municipio union all
	select 'AM' as Estado, 'Itapiranga' as Municipio union all
	select 'AM' as Estado, 'Japurá' as Municipio union all
	select 'AM' as Estado, 'Juruá' as Municipio union all
	select 'AM' as Estado, 'Jutaí' as Municipio union all
	select 'AM' as Estado, 'Lábrea' as Municipio union all
	select 'AM' as Estado, 'Manacapuru' as Municipio union all
	select 'AM' as Estado, 'Manaquiri' as Municipio union all
	select 'AM' as Estado, 'Manaus' as Municipio union all
	select 'AM' as Estado, 'Manicoré' as Municipio union all
	select 'AM' as Estado, 'Maraã' as Municipio union all
	select 'AM' as Estado, 'Maués' as Municipio union all
	select 'AM' as Estado, 'Nhamundá' as Municipio union all
	select 'AM' as Estado, 'Nova Olinda do Norte' as Municipio union all
	select 'AM' as Estado, 'Novo Airão' as Municipio union all
	select 'AM' as Estado, 'Novo Aripuanã' as Municipio union all
	select 'AM' as Estado, 'Parintins' as Municipio union all
	select 'AM' as Estado, 'Pauini' as Municipio union all
	select 'AM' as Estado, 'Presidente Figueiredo' as Municipio union all
	select 'AM' as Estado, 'Rio Preto da Eva' as Municipio union all
	select 'AM' as Estado, 'Santa Isabel do Rio Negro' as Municipio union all
	select 'AM' as Estado, 'Santo Antônio do Içá' as Municipio union all
	select 'AM' as Estado, 'São Gabriel da Cachoeira' as Municipio union all
	select 'AM' as Estado, 'São Paulo de Olivença' as Municipio union all
	select 'AM' as Estado, 'São Sebastião do Uatumã' as Municipio union all
	select 'AM' as Estado, 'Silves' as Municipio union all
	select 'AM' as Estado, 'Tabatinga' as Municipio union all
	select 'AM' as Estado, 'Tapauá' as Municipio union all
	select 'AM' as Estado, 'Tefé' as Municipio union all
	select 'AM' as Estado, 'Tonantins' as Municipio union all
	select 'AM' as Estado, 'Uarini' as Municipio union all
	select 'AM' as Estado, 'Urucará' as Municipio union all
	select 'AM' as Estado, 'Urucurituba' as Municipio union all
	select 'RR' as Estado, 'Alto Alegre' as Municipio union all
	select 'RR' as Estado, 'Amajari' as Municipio union all
	select 'RR' as Estado, 'Boa Vista' as Municipio union all
	select 'RR' as Estado, 'Bonfim' as Municipio union all
	select 'RR' as Estado, 'Cantá' as Municipio union all
	select 'RR' as Estado, 'Caracaraí' as Municipio union all
	select 'RR' as Estado, 'Caroebe' as Municipio union all
	select 'RR' as Estado, 'Iracema' as Municipio union all
	select 'RR' as Estado, 'Mucajaí' as Municipio union all
	select 'RR' as Estado, 'Normandia' as Municipio union all
	select 'RR' as Estado, 'Pacaraima' as Municipio union all
	select 'RR' as Estado, 'Rorainópolis' as Municipio union all
	select 'RR' as Estado, 'São João da Baliza' as Municipio union all
	select 'RR' as Estado, 'São Luiz' as Municipio union all
	select 'RR' as Estado, 'Uiramutã' as Municipio union all
	select 'PA' as Estado, 'Abaetetuba' as Municipio union all
	select 'PA' as Estado, 'Abel Figueiredo' as Municipio union all
	select 'PA' as Estado, 'Acará' as Municipio union all
	select 'PA' as Estado, 'Afuá' as Municipio union all
	select 'PA' as Estado, 'Água Azul do Norte' as Municipio union all
	select 'PA' as Estado, 'Alenquer' as Municipio union all
	select 'PA' as Estado, 'Almeirim' as Municipio union all
	select 'PA' as Estado, 'Altamira' as Municipio union all
	select 'PA' as Estado, 'Anajás' as Municipio union all
	select 'PA' as Estado, 'Ananindeua' as Municipio union all
	select 'PA' as Estado, 'Anapu' as Municipio union all
	select 'PA' as Estado, 'Augusto Corrêa' as Municipio union all
	select 'PA' as Estado, 'Aurora do Pará' as Municipio union all
	select 'PA' as Estado, 'Aveiro' as Municipio union all
	select 'PA' as Estado, 'Bagre' as Municipio union all
	select 'PA' as Estado, 'Baião' as Municipio union all
	select 'PA' as Estado, 'Bannach' as Municipio union all
	select 'PA' as Estado, 'Barcarena' as Municipio union all
	select 'PA' as Estado, 'Belém' as Municipio union all
	select 'PA' as Estado, 'Belterra' as Municipio union all
	select 'PA' as Estado, 'Benevides' as Municipio union all
	select 'PA' as Estado, 'Bom Jesus do Tocantins' as Municipio union all
	select 'PA' as Estado, 'Bonito' as Municipio union all
	select 'PA' as Estado, 'Bragança' as Municipio union all
	select 'PA' as Estado, 'Brasil Novo' as Municipio union all
	select 'PA' as Estado, 'Brejo Grande do Araguaia' as Municipio union all
	select 'PA' as Estado, 'Breu Branco' as Municipio union all
	select 'PA' as Estado, 'Breves' as Municipio union all
	select 'PA' as Estado, 'Bujaru' as Municipio union all
	select 'PA' as Estado, 'Cachoeira do Arari' as Municipio union all
	select 'PA' as Estado, 'Cachoeira do Piriá' as Municipio union all
	select 'PA' as Estado, 'Cametá' as Municipio union all
	select 'PA' as Estado, 'Canaã dos Carajás' as Municipio union all
	select 'PA' as Estado, 'Capanema' as Municipio union all
	select 'PA' as Estado, 'Capitão Poço' as Municipio union all
	select 'PA' as Estado, 'Castanhal' as Municipio union all
	select 'PA' as Estado, 'Chaves' as Municipio union all
	select 'PA' as Estado, 'Colares' as Municipio union all
	select 'PA' as Estado, 'Conceição do Araguaia' as Municipio union all
	select 'PA' as Estado, 'Concórdia do Pará' as Municipio union all
	select 'PA' as Estado, 'Cumaru do Norte' as Municipio union all
	select 'PA' as Estado, 'Curionópolis' as Municipio union all
	select 'PA' as Estado, 'Curralinho' as Municipio union all
	select 'PA' as Estado, 'Curuá' as Municipio union all
	select 'PA' as Estado, 'Curuçá' as Municipio union all
	select 'PA' as Estado, 'Dom Eliseu' as Municipio union all
	select 'PA' as Estado, 'Eldorado dos Carajás' as Municipio union all
	select 'PA' as Estado, 'Faro' as Municipio union all
	select 'PA' as Estado, 'Floresta do Araguaia' as Municipio union all
	select 'PA' as Estado, 'Garrafão do Norte' as Municipio union all
	select 'PA' as Estado, 'Goianésia do Pará' as Municipio union all
	select 'PA' as Estado, 'Gurupá' as Municipio union all
	select 'PA' as Estado, 'Igarapé-Açu' as Municipio union all
	select 'PA' as Estado, 'Igarapé-Miri' as Municipio union all
	select 'PA' as Estado, 'Inhangapi' as Municipio union all
	select 'PA' as Estado, 'Ipixuna do Pará' as Municipio union all
	select 'PA' as Estado, 'Irituia' as Municipio union all
	select 'PA' as Estado, 'Itaituba' as Municipio union all
	select 'PA' as Estado, 'Itupiranga' as Municipio union all
	select 'PA' as Estado, 'Jacareacanga' as Municipio union all
	select 'PA' as Estado, 'Jacundá' as Municipio union all
	select 'PA' as Estado, 'Juruti' as Municipio union all
	select 'PA' as Estado, 'Limoeiro do Ajuru' as Municipio union all
	select 'PA' as Estado, 'Mãe do Rio' as Municipio union all
	select 'PA' as Estado, 'Magalhães Barata' as Municipio union all
	select 'PA' as Estado, 'Marabá' as Municipio union all
	select 'PA' as Estado, 'Maracanã' as Municipio union all
	select 'PA' as Estado, 'Marapanim' as Municipio union all
	select 'PA' as Estado, 'Marituba' as Municipio union all
	select 'PA' as Estado, 'Medicilândia' as Municipio union all
	select 'PA' as Estado, 'Melgaço' as Municipio union all
	select 'PA' as Estado, 'Mocajuba' as Municipio union all
	select 'PA' as Estado, 'Moju' as Municipio union all
	select 'PA' as Estado, 'Monte Alegre' as Municipio union all
	select 'PA' as Estado, 'Muaná' as Municipio union all
	select 'PA' as Estado, 'Nova Esperança do Piriá' as Municipio union all
	select 'PA' as Estado, 'Nova Ipixuna' as Municipio union all
	select 'PA' as Estado, 'Nova Timboteua' as Municipio union all
	select 'PA' as Estado, 'Novo Progresso' as Municipio union all
	select 'PA' as Estado, 'Novo Repartimento' as Municipio union all
	select 'PA' as Estado, 'Óbidos' as Municipio union all
	select 'PA' as Estado, 'Oeiras do Pará' as Municipio union all
	select 'PA' as Estado, 'Oriximiná' as Municipio union all
	select 'PA' as Estado, 'Ourém' as Municipio union all
	select 'PA' as Estado, 'Ourilândia do Norte' as Municipio union all
	select 'PA' as Estado, 'Pacajá' as Municipio union all
	select 'PA' as Estado, 'Palestina do Pará' as Municipio union all
	select 'PA' as Estado, 'Paragominas' as Municipio union all
	select 'PA' as Estado, 'Parauapebas' as Municipio union all
	select 'PA' as Estado, 'Pau D''Arco' as Municipio union all
	select 'PA' as Estado, 'Peixe-Boi' as Municipio union all
	select 'PA' as Estado, 'Piçarra' as Municipio union all
	select 'PA' as Estado, 'Placas' as Municipio union all
	select 'PA' as Estado, 'Ponta de Pedras' as Municipio union all
	select 'PA' as Estado, 'Portel' as Municipio union all
	select 'PA' as Estado, 'Porto de Moz' as Municipio union all
	select 'PA' as Estado, 'Prainha' as Municipio union all
	select 'PA' as Estado, 'Primavera' as Municipio union all
	select 'PA' as Estado, 'Quatipuru' as Municipio union all
	select 'PA' as Estado, 'Redenção' as Municipio union all
	select 'PA' as Estado, 'Rio Maria' as Municipio union all
	select 'PA' as Estado, 'Rondon do Pará' as Municipio union all
	select 'PA' as Estado, 'Rurópolis' as Municipio union all
	select 'PA' as Estado, 'Salinópolis' as Municipio union all
	select 'PA' as Estado, 'Salvaterra' as Municipio union all
	select 'PA' as Estado, 'Santa Bárbara do Pará' as Municipio union all
	select 'PA' as Estado, 'Santa Cruz do Arari' as Municipio union all
	select 'PA' as Estado, 'Santa Isabel do Pará' as Municipio union all
	select 'PA' as Estado, 'Santa Luzia do Pará' as Municipio union all
	select 'PA' as Estado, 'Santa Maria das Barreiras' as Municipio union all
	select 'PA' as Estado, 'Santa Maria do Pará' as Municipio union all
	select 'PA' as Estado, 'Santana do Araguaia' as Municipio union all
	select 'PA' as Estado, 'Santarém' as Municipio union all
	select 'PA' as Estado, 'Santarém Novo' as Municipio union all
	select 'PA' as Estado, 'Santo Antônio do Tauá' as Municipio union all
	select 'PA' as Estado, 'São Caetano de Odivelas' as Municipio union all
	select 'PA' as Estado, 'São Domingos do Araguaia' as Municipio union all
	select 'PA' as Estado, 'São Domingos do Capim' as Municipio union all
	select 'PA' as Estado, 'São Félix do Xingu' as Municipio union all
	select 'PA' as Estado, 'São Francisco do Pará' as Municipio union all
	select 'PA' as Estado, 'São Geraldo do Araguaia' as Municipio union all
	select 'PA' as Estado, 'São João da Ponta' as Municipio union all
	select 'PA' as Estado, 'São João de Pirabas' as Municipio union all
	select 'PA' as Estado, 'São João do Araguaia' as Municipio union all
	select 'PA' as Estado, 'São Miguel do Guamá' as Municipio union all
	select 'PA' as Estado, 'São Sebastião da Boa Vista' as Municipio union all
	select 'PA' as Estado, 'Sapucaia' as Municipio union all
	select 'PA' as Estado, 'Senador José Porfírio' as Municipio union all
	select 'PA' as Estado, 'Soure' as Municipio union all
	select 'PA' as Estado, 'Tailândia' as Municipio union all
	select 'PA' as Estado, 'Terra Alta' as Municipio union all
	select 'PA' as Estado, 'Terra Santa' as Municipio union all
	select 'PA' as Estado, 'Tomé-Açu' as Municipio union all
	select 'PA' as Estado, 'Tracuateua' as Municipio union all
	select 'PA' as Estado, 'Trairão' as Municipio union all
	select 'PA' as Estado, 'Tucumã' as Municipio union all
	select 'PA' as Estado, 'Tucuruí' as Municipio union all
	select 'PA' as Estado, 'Ulianópolis' as Municipio union all
	select 'PA' as Estado, 'Uruará (por decisão judicial)' as Municipio union all
	select 'PA' as Estado, 'Vigia' as Municipio union all
	select 'PA' as Estado, 'Viseu' as Municipio union all
	select 'PA' as Estado, 'Vitória do Xingu' as Municipio union all
	select 'PA' as Estado, 'Xinguara' as Municipio union all
	select 'AP' as Estado, 'Amapá' as Municipio union all
	select 'AP' as Estado, 'Calçoene' as Municipio union all
	select 'AP' as Estado, 'Cutias' as Municipio union all
	select 'AP' as Estado, 'Ferreira Gomes' as Municipio union all
	select 'AP' as Estado, 'Itaubal' as Municipio union all
	select 'AP' as Estado, 'Laranjal do Jari' as Municipio union all
	select 'AP' as Estado, 'Macapá' as Municipio union all
	select 'AP' as Estado, 'Mazagão' as Municipio union all
	select 'AP' as Estado, 'Oiapoque' as Municipio union all
	select 'AP' as Estado, 'Pedra Branca do Amapari' as Municipio union all
	select 'AP' as Estado, 'Porto Grande' as Municipio union all
	select 'AP' as Estado, 'Pracuúba' as Municipio union all
	select 'AP' as Estado, 'Santana' as Municipio union all
	select 'AP' as Estado, 'Serra do Navio' as Municipio union all
	select 'AP' as Estado, 'Tartarugalzinho' as Municipio union all
	select 'AP' as Estado, 'Vitória do Jari' as Municipio union all
	select 'TO' as Estado, 'Abreulândia' as Municipio union all
	select 'TO' as Estado, 'Aguiarnópolis' as Municipio union all
	select 'TO' as Estado, 'Aliança do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Almas' as Municipio union all
	select 'TO' as Estado, 'Alvorada' as Municipio union all
	select 'TO' as Estado, 'Ananás' as Municipio union all
	select 'TO' as Estado, 'Angico' as Municipio union all
	select 'TO' as Estado, 'Aparecida do Rio Negro' as Municipio union all
	select 'TO' as Estado, 'Aragominas' as Municipio union all
	select 'TO' as Estado, 'Araguacema' as Municipio union all
	select 'TO' as Estado, 'Araguaçu' as Municipio union all
	select 'TO' as Estado, 'Araguaína' as Municipio union all
	select 'TO' as Estado, 'Araguanã' as Municipio union all
	select 'TO' as Estado, 'Araguatins' as Municipio union all
	select 'TO' as Estado, 'Arapoema' as Municipio union all
	select 'TO' as Estado, 'Arraias' as Municipio union all
	select 'TO' as Estado, 'Augustinópolis' as Municipio union all
	select 'TO' as Estado, 'Aurora do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Axixá do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Babaçulândia' as Municipio union all
	select 'TO' as Estado, 'Bandeirantes do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Barra do Ouro' as Municipio union all
	select 'TO' as Estado, 'Barrolândia' as Municipio union all
	select 'TO' as Estado, 'Bernardo Sayão' as Municipio union all
	select 'TO' as Estado, 'Bom Jesus do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Brasilândia do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Brejinho de Nazaré' as Municipio union all
	select 'TO' as Estado, 'Buriti do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Cachoeirinha' as Municipio union all
	select 'TO' as Estado, 'Campos Lindos' as Municipio union all
	select 'TO' as Estado, 'Cariri do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Carmolândia' as Municipio union all
	select 'TO' as Estado, 'Carrasco Bonito' as Municipio union all
	select 'TO' as Estado, 'Caseara' as Municipio union all
	select 'TO' as Estado, 'Centenário' as Municipio union all
	select 'TO' as Estado, 'Chapada da Natividade' as Municipio union all
	select 'TO' as Estado, 'Chapada de Areia' as Municipio union all
	select 'TO' as Estado, 'Colinas do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Colméia' as Municipio union all
	select 'TO' as Estado, 'Combinado' as Municipio union all
	select 'TO' as Estado, 'Conceição do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Couto de Magalhães' as Municipio union all
	select 'TO' as Estado, 'Cristalândia' as Municipio union all
	select 'TO' as Estado, 'Crixás do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Darcinópolis' as Municipio union all
	select 'TO' as Estado, 'Dianópolis' as Municipio union all
	select 'TO' as Estado, 'Divinópolis do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Dois Irmãos do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Dueré' as Municipio union all
	select 'TO' as Estado, 'Esperantina' as Municipio union all
	select 'TO' as Estado, 'Fátima' as Municipio union all
	select 'TO' as Estado, 'Figueirópolis' as Municipio union all
	select 'TO' as Estado, 'Filadélfia' as Municipio union all
	select 'TO' as Estado, 'Formoso do Araguaia' as Municipio union all
	select 'TO' as Estado, 'Fortaleza do Tabocão' as Municipio union all
	select 'TO' as Estado, 'Goianorte' as Municipio union all
	select 'TO' as Estado, 'Goiatins' as Municipio union all
	select 'TO' as Estado, 'Guaraí' as Municipio union all
	select 'TO' as Estado, 'Gurupi' as Municipio union all
	select 'TO' as Estado, 'Ipueiras' as Municipio union all
	select 'TO' as Estado, 'Itacajá' as Municipio union all
	select 'TO' as Estado, 'Itaguatins' as Municipio union all
	select 'TO' as Estado, 'Itapiratins' as Municipio union all
	select 'TO' as Estado, 'Itaporã do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Jaú do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Juarina' as Municipio union all
	select 'TO' as Estado, 'Lagoa da Confusão' as Municipio union all
	select 'TO' as Estado, 'Lagoa do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Lajeado' as Municipio union all
	select 'TO' as Estado, 'Lavandeira' as Municipio union all
	select 'TO' as Estado, 'Lizarda' as Municipio union all
	select 'TO' as Estado, 'Luzinópolis' as Municipio union all
	select 'TO' as Estado, 'Marianópolis do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Mateiros' as Municipio union all
	select 'TO' as Estado, 'Maurilândia do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Miracema do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Miranorte' as Municipio union all
	select 'TO' as Estado, 'Monte do Carmo' as Municipio union all
	select 'TO' as Estado, 'Monte Santo do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Muricilândia' as Municipio union all
	select 'TO' as Estado, 'Natividade' as Municipio union all
	select 'TO' as Estado, 'Nazaré' as Municipio union all
	select 'TO' as Estado, 'Nova Olinda' as Municipio union all
	select 'TO' as Estado, 'Nova Rosalândia' as Municipio union all
	select 'TO' as Estado, 'Novo Acordo' as Municipio union all
	select 'TO' as Estado, 'Novo Alegre' as Municipio union all
	select 'TO' as Estado, 'Novo Jardim' as Municipio union all
	select 'TO' as Estado, 'Oliveira de Fátima' as Municipio union all
	select 'TO' as Estado, 'Palmas' as Municipio union all
	select 'TO' as Estado, 'Palmeirante' as Municipio union all
	select 'TO' as Estado, 'Palmeiras do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Palmeirópolis' as Municipio union all
	select 'TO' as Estado, 'Paraíso do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Paranã' as Municipio union all
	select 'TO' as Estado, 'Pau D''Arco' as Municipio union all
	select 'TO' as Estado, 'Pedro Afonso' as Municipio union all
	select 'TO' as Estado, 'Peixe' as Municipio union all
	select 'TO' as Estado, 'Pequizeiro' as Municipio union all
	select 'TO' as Estado, 'Pindorama do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Piraquê' as Municipio union all
	select 'TO' as Estado, 'Pium' as Municipio union all
	select 'TO' as Estado, 'Ponte Alta do Bom Jesus' as Municipio union all
	select 'TO' as Estado, 'Ponte Alta do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Porto Alegre do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Porto Nacional' as Municipio union all
	select 'TO' as Estado, 'Praia Norte' as Municipio union all
	select 'TO' as Estado, 'Presidente Kennedy' as Municipio union all
	select 'TO' as Estado, 'Pugmil' as Municipio union all
	select 'TO' as Estado, 'Recursolândia' as Municipio union all
	select 'TO' as Estado, 'Riachinho' as Municipio union all
	select 'TO' as Estado, 'Rio da Conceição' as Municipio union all
	select 'TO' as Estado, 'Rio dos Bois' as Municipio union all
	select 'TO' as Estado, 'Rio Sono' as Municipio union all
	select 'TO' as Estado, 'Sampaio' as Municipio union all
	select 'TO' as Estado, 'Sandolândia' as Municipio union all
	select 'TO' as Estado, 'Santa Fé do Araguaia' as Municipio union all
	select 'TO' as Estado, 'Santa Maria do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Santa Rita do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Santa Rosa do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Santa Tereza do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Santa Terezinha do Tocantins' as Municipio union all
	select 'TO' as Estado, 'São Bento do Tocantins' as Municipio union all
	select 'TO' as Estado, 'São Félix do Tocantins' as Municipio union all
	select 'TO' as Estado, 'São Miguel do Tocantins' as Municipio union all
	select 'TO' as Estado, 'São Salvador do Tocantins' as Municipio union all
	select 'TO' as Estado, 'São Sebastião do Tocantins' as Municipio union all
	select 'TO' as Estado, 'São Valério da Natividade' as Municipio union all
	select 'TO' as Estado, 'Silvanópolis' as Municipio union all
	select 'TO' as Estado, 'Sítio Novo do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Sucupira' as Municipio union all
	select 'TO' as Estado, 'Taguatinga' as Municipio union all
	select 'TO' as Estado, 'Taipas do Tocantins' as Municipio union all
	select 'TO' as Estado, 'Talismã' as Municipio union all
	select 'TO' as Estado, 'Tocantínia' as Municipio union all
	select 'TO' as Estado, 'Tocantinópolis' as Municipio union all
	select 'TO' as Estado, 'Tupirama' as Municipio union all
	select 'TO' as Estado, 'Tupiratins' as Municipio union all
	select 'TO' as Estado, 'Wanderlândia' as Municipio union all
	select 'TO' as Estado, 'Xambioá' as Municipio union all
	select 'MA' as Estado, 'Açailândia' as Municipio union all
	select 'MA' as Estado, 'Afonso Cunha' as Municipio union all
	select 'MA' as Estado, 'Água Doce do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Alcântara' as Municipio union all
	select 'MA' as Estado, 'Aldeias Altas' as Municipio union all
	select 'MA' as Estado, 'Altamira do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Alto Alegre do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Alto Alegre do Pindaré' as Municipio union all
	select 'MA' as Estado, 'Alto Parnaíba' as Municipio union all
	select 'MA' as Estado, 'Amapá do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Amarante do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Anajatuba' as Municipio union all
	select 'MA' as Estado, 'Anapurus' as Municipio union all
	select 'MA' as Estado, 'Apicum-Açu' as Municipio union all
	select 'MA' as Estado, 'Araguanã' as Municipio union all
	select 'MA' as Estado, 'Araioses' as Municipio union all
	select 'MA' as Estado, 'Arame' as Municipio union all
	select 'MA' as Estado, 'Arari' as Municipio union all
	select 'MA' as Estado, 'Axixá' as Municipio union all
	select 'MA' as Estado, 'Bacabal' as Municipio union all
	select 'MA' as Estado, 'Bacabeira' as Municipio union all
	select 'MA' as Estado, 'Bacuri' as Municipio union all
	select 'MA' as Estado, 'Bacurituba' as Municipio union all
	select 'MA' as Estado, 'Balsas' as Municipio union all
	select 'MA' as Estado, 'Barão de Grajaú' as Municipio union all
	select 'MA' as Estado, 'Barra do Corda' as Municipio union all
	select 'MA' as Estado, 'Barreirinhas' as Municipio union all
	select 'MA' as Estado, 'Bela Vista do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Belágua' as Municipio union all
	select 'MA' as Estado, 'Benedito Leite' as Municipio union all
	select 'MA' as Estado, 'Bequimão' as Municipio union all
	select 'MA' as Estado, 'Bernardo do Mearim' as Municipio union all
	select 'MA' as Estado, 'Boa Vista do Gurupi' as Municipio union all
	select 'MA' as Estado, 'Bom Jardim' as Municipio union all
	select 'MA' as Estado, 'Bom Jesus das Selvas' as Municipio union all
	select 'MA' as Estado, 'Bom Lugar' as Municipio union all
	select 'MA' as Estado, 'Brejo' as Municipio union all
	select 'MA' as Estado, 'Brejo de Areia' as Municipio union all
	select 'MA' as Estado, 'Buriti' as Municipio union all
	select 'MA' as Estado, 'Buriti Bravo' as Municipio union all
	select 'MA' as Estado, 'Buriticupu' as Municipio union all
	select 'MA' as Estado, 'Buritirana' as Municipio union all
	select 'MA' as Estado, 'Cachoeira Grande' as Municipio union all
	select 'MA' as Estado, 'Cajapió' as Municipio union all
	select 'MA' as Estado, 'Cajari' as Municipio union all
	select 'MA' as Estado, 'Campestre do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Cândido Mendes' as Municipio union all
	select 'MA' as Estado, 'Cantanhede' as Municipio union all
	select 'MA' as Estado, 'Capinzal do Norte' as Municipio union all
	select 'MA' as Estado, 'Carolina' as Municipio union all
	select 'MA' as Estado, 'Carutapera' as Municipio union all
	select 'MA' as Estado, 'Caxias' as Municipio union all
	select 'MA' as Estado, 'Cedral' as Municipio union all
	select 'MA' as Estado, 'Central do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Centro do Guilherme' as Municipio union all
	select 'MA' as Estado, 'Centro Novo do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Chapadinha' as Municipio union all
	select 'MA' as Estado, 'Cidelândia' as Municipio union all
	select 'MA' as Estado, 'Codó' as Municipio union all
	select 'MA' as Estado, 'Coelho Neto' as Municipio union all
	select 'MA' as Estado, 'Colinas' as Municipio union all
	select 'MA' as Estado, 'Conceição do Lago-Açu' as Municipio union all
	select 'MA' as Estado, 'Coroatá' as Municipio union all
	select 'MA' as Estado, 'Cururupu' as Municipio union all
	select 'MA' as Estado, 'Davinópolis' as Municipio union all
	select 'MA' as Estado, 'Dom Pedro' as Municipio union all
	select 'MA' as Estado, 'Duque Bacelar' as Municipio union all
	select 'MA' as Estado, 'Esperantinópolis' as Municipio union all
	select 'MA' as Estado, 'Estreito' as Municipio union all
	select 'MA' as Estado, 'Feira Nova do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Fernando Falcão' as Municipio union all
	select 'MA' as Estado, 'Formosa da Serra Negra' as Municipio union all
	select 'MA' as Estado, 'Fortaleza dos Nogueiras' as Municipio union all
	select 'MA' as Estado, 'Fortuna' as Municipio union all
	select 'MA' as Estado, 'Godofredo Viana' as Municipio union all
	select 'MA' as Estado, 'Gonçalves Dias' as Municipio union all
	select 'MA' as Estado, 'Governador Archer' as Municipio union all
	select 'MA' as Estado, 'Governador Edison Lobão' as Municipio union all
	select 'MA' as Estado, 'Governador Eugênio Barros' as Municipio union all
	select 'MA' as Estado, 'Governador Luiz Rocha' as Municipio union all
	select 'MA' as Estado, 'Governador Newton Bello' as Municipio union all
	select 'MA' as Estado, 'Governador Nunes Freire' as Municipio union all
	select 'MA' as Estado, 'Graça Aranha' as Municipio union all
	select 'MA' as Estado, 'Grajaú' as Municipio union all
	select 'MA' as Estado, 'Guimarães' as Municipio union all
	select 'MA' as Estado, 'Humberto de Campos' as Municipio union all
	select 'MA' as Estado, 'Icatu' as Municipio union all
	select 'MA' as Estado, 'Igarapé do Meio' as Municipio union all
	select 'MA' as Estado, 'Igarapé Grande' as Municipio union all
	select 'MA' as Estado, 'Imperatriz' as Municipio union all
	select 'MA' as Estado, 'Itaipava do Grajaú' as Municipio union all
	select 'MA' as Estado, 'Itapecuru Mirim' as Municipio union all
	select 'MA' as Estado, 'Itinga do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Jatobá' as Municipio union all
	select 'MA' as Estado, 'Jenipapo dos Vieiras' as Municipio union all
	select 'MA' as Estado, 'João Lisboa' as Municipio union all
	select 'MA' as Estado, 'Joselândia' as Municipio union all
	select 'MA' as Estado, 'Junco do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Lago da Pedra' as Municipio union all
	select 'MA' as Estado, 'Lago do Junco' as Municipio union all
	select 'MA' as Estado, 'Lago dos Rodrigues' as Municipio union all
	select 'MA' as Estado, 'Lago Verde' as Municipio union all
	select 'MA' as Estado, 'Lagoa do Mato' as Municipio union all
	select 'MA' as Estado, 'Lagoa Grande do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Lajeado Novo' as Municipio union all
	select 'MA' as Estado, 'Lima Campos' as Municipio union all
	select 'MA' as Estado, 'Loreto' as Municipio union all
	select 'MA' as Estado, 'Luís Domingues' as Municipio union all
	select 'MA' as Estado, 'Magalhães de Almeida' as Municipio union all
	select 'MA' as Estado, 'Maracaçumé' as Municipio union all
	select 'MA' as Estado, 'Marajá do Sena' as Municipio union all
	select 'MA' as Estado, 'Maranhãozinho' as Municipio union all
	select 'MA' as Estado, 'Mata Roma' as Municipio union all
	select 'MA' as Estado, 'Matinha' as Municipio union all
	select 'MA' as Estado, 'Matões' as Municipio union all
	select 'MA' as Estado, 'Matões do Norte' as Municipio union all
	select 'MA' as Estado, 'Milagres do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Mirador' as Municipio union all
	select 'MA' as Estado, 'Miranda do Norte' as Municipio union all
	select 'MA' as Estado, 'Mirinzal' as Municipio union all
	select 'MA' as Estado, 'Monção' as Municipio union all
	select 'MA' as Estado, 'Montes Altos' as Municipio union all
	select 'MA' as Estado, 'Morros' as Municipio union all
	select 'MA' as Estado, 'Nina Rodrigues' as Municipio union all
	select 'MA' as Estado, 'Nova Colinas' as Municipio union all
	select 'MA' as Estado, 'Nova Iorque' as Municipio union all
	select 'MA' as Estado, 'Nova Olinda do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Olho d''Água das Cunhãs' as Municipio union all
	select 'MA' as Estado, 'Olinda Nova do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Paço do Lumiar' as Municipio union all
	select 'MA' as Estado, 'Palmeirândia' as Municipio union all
	select 'MA' as Estado, 'Paraibano' as Municipio union all
	select 'MA' as Estado, 'Parnarama' as Municipio union all
	select 'MA' as Estado, 'Passagem Franca' as Municipio union all
	select 'MA' as Estado, 'Pastos Bons' as Municipio union all
	select 'MA' as Estado, 'Paulino Neves' as Municipio union all
	select 'MA' as Estado, 'Paulo Ramos' as Municipio union all
	select 'MA' as Estado, 'Pedreiras' as Municipio union all
	select 'MA' as Estado, 'Pedro do Rosário' as Municipio union all
	select 'MA' as Estado, 'Penalva' as Municipio union all
	select 'MA' as Estado, 'Peri Mirim' as Municipio union all
	select 'MA' as Estado, 'Peritoró' as Municipio union all
	select 'MA' as Estado, 'Pindaré-Mirim' as Municipio union all
	select 'MA' as Estado, 'Pinheiro' as Municipio union all
	select 'MA' as Estado, 'Pio XII' as Municipio union all
	select 'MA' as Estado, 'Pirapemas' as Municipio union all
	select 'MA' as Estado, 'Poção de Pedras' as Municipio union all
	select 'MA' as Estado, 'Porto Franco' as Municipio union all
	select 'MA' as Estado, 'Porto Rico do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Presidente Dutra' as Municipio union all
	select 'MA' as Estado, 'Presidente Juscelino' as Municipio union all
	select 'MA' as Estado, 'Presidente Médici' as Municipio union all
	select 'MA' as Estado, 'Presidente Sarney' as Municipio union all
	select 'MA' as Estado, 'Presidente Vargas' as Municipio union all
	select 'MA' as Estado, 'Primeira Cruz' as Municipio union all
	select 'MA' as Estado, 'Raposa' as Municipio union all
	select 'MA' as Estado, 'Riachão' as Municipio union all
	select 'MA' as Estado, 'Ribamar Fiquene' as Municipio union all
	select 'MA' as Estado, 'Rosário' as Municipio union all
	select 'MA' as Estado, 'Sambaíba' as Municipio union all
	select 'MA' as Estado, 'Santa Filomena do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Santa Helena' as Municipio union all
	select 'MA' as Estado, 'Santa Inês' as Municipio union all
	select 'MA' as Estado, 'Santa Luzia' as Municipio union all
	select 'MA' as Estado, 'Santa Luzia do Paruá' as Municipio union all
	select 'MA' as Estado, 'Santa Quitéria do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Santa Rita' as Municipio union all
	select 'MA' as Estado, 'Santana do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Santo Amaro do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Santo Antônio dos Lopes' as Municipio union all
	select 'MA' as Estado, 'São Benedito do Rio Preto' as Municipio union all
	select 'MA' as Estado, 'São Bento' as Municipio union all
	select 'MA' as Estado, 'São Bernardo' as Municipio union all
	select 'MA' as Estado, 'São Domingos do Azeitão' as Municipio union all
	select 'MA' as Estado, 'São Domingos do Maranhão' as Municipio union all
	select 'MA' as Estado, 'São Félix de Balsas' as Municipio union all
	select 'MA' as Estado, 'São Francisco do Brejão' as Municipio union all
	select 'MA' as Estado, 'São Francisco do Maranhão' as Municipio union all
	select 'MA' as Estado, 'São João Batista' as Municipio union all
	select 'MA' as Estado, 'São João do Carú' as Municipio union all
	select 'MA' as Estado, 'São João do Paraíso' as Municipio union all
	select 'MA' as Estado, 'São João do Soter' as Municipio union all
	select 'MA' as Estado, 'São João dos Patos' as Municipio union all
	select 'MA' as Estado, 'São José de Ribamar' as Municipio union all
	select 'MA' as Estado, 'São José dos Basílios' as Municipio union all
	select 'MA' as Estado, 'São Luís' as Municipio union all
	select 'MA' as Estado, 'São Luís Gonzaga do Maranhão' as Municipio union all
	select 'MA' as Estado, 'São Mateus do Maranhão' as Municipio union all
	select 'MA' as Estado, 'São Pedro da Água Branca' as Municipio union all
	select 'MA' as Estado, 'São Pedro dos Crentes' as Municipio union all
	select 'MA' as Estado, 'São Raimundo das Mangabeiras' as Municipio union all
	select 'MA' as Estado, 'São Raimundo do Doca Bezerra' as Municipio union all
	select 'MA' as Estado, 'São Roberto' as Municipio union all
	select 'MA' as Estado, 'São Vicente Ferrer' as Municipio union all
	select 'MA' as Estado, 'Satubinha' as Municipio union all
	select 'MA' as Estado, 'Senador Alexandre Costa' as Municipio union all
	select 'MA' as Estado, 'Senador La Rocque' as Municipio union all
	select 'MA' as Estado, 'Serrano do Maranhão' as Municipio union all
	select 'MA' as Estado, 'Sítio Novo' as Municipio union all
	select 'MA' as Estado, 'Sucupira do Norte' as Municipio union all
	select 'MA' as Estado, 'Sucupira do Riachão' as Municipio union all
	select 'MA' as Estado, 'Tasso Fragoso' as Municipio union all
	select 'MA' as Estado, 'Timbiras' as Municipio union all
	select 'MA' as Estado, 'Timon' as Municipio union all
	select 'MA' as Estado, 'Trizidela do Vale' as Municipio union all
	select 'MA' as Estado, 'Tufilândia' as Municipio union all
	select 'MA' as Estado, 'Tuntum' as Municipio union all
	select 'MA' as Estado, 'Turiaçu' as Municipio union all
	select 'MA' as Estado, 'Turilândia' as Municipio union all
	select 'MA' as Estado, 'Tutóia' as Municipio union all
	select 'MA' as Estado, 'Urbano Santos' as Municipio union all
	select 'MA' as Estado, 'Vargem Grande' as Municipio union all
	select 'MA' as Estado, 'Viana' as Municipio union all
	select 'MA' as Estado, 'Vila Nova dos Martírios' as Municipio union all
	select 'MA' as Estado, 'Vitória do Mearim' as Municipio union all
	select 'MA' as Estado, 'Vitorino Freire' as Municipio union all
	select 'MA' as Estado, 'Zé Doca' as Municipio union all
	select 'PI' as Estado, 'Acauã' as Municipio union all
	select 'PI' as Estado, 'Agricolândia' as Municipio union all
	select 'PI' as Estado, 'Água Branca' as Municipio union all
	select 'PI' as Estado, 'Alagoinha do Piauí' as Municipio union all
	select 'PI' as Estado, 'Alegrete do Piauí' as Municipio union all
	select 'PI' as Estado, 'Alto Longá' as Municipio union all
	select 'PI' as Estado, 'Altos' as Municipio union all
	select 'PI' as Estado, 'Alvorada do Gurguéia' as Municipio union all
	select 'PI' as Estado, 'Amarante' as Municipio union all
	select 'PI' as Estado, 'Angical do Piauí' as Municipio union all
	select 'PI' as Estado, 'Anísio de Abreu' as Municipio union all
	select 'PI' as Estado, 'Antônio Almeida' as Municipio union all
	select 'PI' as Estado, 'Aroazes' as Municipio union all
	select 'PI' as Estado, 'Aroeiras do Itaim' as Municipio union all
	select 'PI' as Estado, 'Arraial' as Municipio union all
	select 'PI' as Estado, 'Assunção do Piauí' as Municipio union all
	select 'PI' as Estado, 'Avelino Lopes' as Municipio union all
	select 'PI' as Estado, 'Baixa Grande do Ribeiro' as Municipio union all
	select 'PI' as Estado, 'Barra D''Alcântara' as Municipio union all
	select 'PI' as Estado, 'Barras' as Municipio union all
	select 'PI' as Estado, 'Barreiras do Piauí' as Municipio union all
	select 'PI' as Estado, 'Barro Duro' as Municipio union all
	select 'PI' as Estado, 'Batalha' as Municipio union all
	select 'PI' as Estado, 'Bela Vista do Piauí' as Municipio union all
	select 'PI' as Estado, 'Belém do Piauí' as Municipio union all
	select 'PI' as Estado, 'Beneditinos' as Municipio union all
	select 'PI' as Estado, 'Bertolínia' as Municipio union all
	select 'PI' as Estado, 'Betânia do Piauí' as Municipio union all
	select 'PI' as Estado, 'Boa Hora' as Municipio union all
	select 'PI' as Estado, 'Bocaina' as Municipio union all
	select 'PI' as Estado, 'Bom Jesus' as Municipio union all
	select 'PI' as Estado, 'Bom Princípio do Piauí' as Municipio union all
	select 'PI' as Estado, 'Bonfim do Piauí' as Municipio union all
	select 'PI' as Estado, 'Boqueirão do Piauí' as Municipio union all
	select 'PI' as Estado, 'Brasileira' as Municipio union all
	select 'PI' as Estado, 'Brejo do Piauí' as Municipio union all
	select 'PI' as Estado, 'Buriti dos Lopes' as Municipio union all
	select 'PI' as Estado, 'Buriti dos Montes' as Municipio union all
	select 'PI' as Estado, 'Cabeceiras do Piauí' as Municipio union all
	select 'PI' as Estado, 'Cajazeiras do Piauí' as Municipio union all
	select 'PI' as Estado, 'Cajueiro da Praia' as Municipio union all
	select 'PI' as Estado, 'Caldeirão Grande do Piauí' as Municipio union all
	select 'PI' as Estado, 'Campinas do Piauí' as Municipio union all
	select 'PI' as Estado, 'Campo Alegre do Fidalgo' as Municipio union all
	select 'PI' as Estado, 'Campo Grande do Piauí' as Municipio union all
	select 'PI' as Estado, 'Campo Largo do Piauí' as Municipio union all
	select 'PI' as Estado, 'Campo Maior' as Municipio union all
	select 'PI' as Estado, 'Canavieira' as Municipio union all
	select 'PI' as Estado, 'Canto do Buriti' as Municipio union all
	select 'PI' as Estado, 'Capitão de Campos' as Municipio union all
	select 'PI' as Estado, 'Capitão Gervásio Oliveira' as Municipio union all
	select 'PI' as Estado, 'Caracol' as Municipio union all
	select 'PI' as Estado, 'Caraúbas do Piauí' as Municipio union all
	select 'PI' as Estado, 'Caridade do Piauí' as Municipio union all
	select 'PI' as Estado, 'Castelo do Piauí' as Municipio union all
	select 'PI' as Estado, 'Caxingó' as Municipio union all
	select 'PI' as Estado, 'Cocal' as Municipio union all
	select 'PI' as Estado, 'Cocal de Telha' as Municipio union all
	select 'PI' as Estado, 'Cocal dos Alves' as Municipio union all
	select 'PI' as Estado, 'Coivaras' as Municipio union all
	select 'PI' as Estado, 'Colônia do Gurguéia' as Municipio union all
	select 'PI' as Estado, 'Colônia do Piauí' as Municipio union all
	select 'PI' as Estado, 'Conceição do Canindé' as Municipio union all
	select 'PI' as Estado, 'Coronel José Dias' as Municipio union all
	select 'PI' as Estado, 'Corrente' as Municipio union all
	select 'PI' as Estado, 'Cristalândia do Piauí' as Municipio union all
	select 'PI' as Estado, 'Cristino Castro' as Municipio union all
	select 'PI' as Estado, 'Curimatá' as Municipio union all
	select 'PI' as Estado, 'Currais' as Municipio union all
	select 'PI' as Estado, 'Curral Novo do Piauí' as Municipio union all
	select 'PI' as Estado, 'Curralinhos' as Municipio union all
	select 'PI' as Estado, 'Demerval Lobão' as Municipio union all
	select 'PI' as Estado, 'Dirceu Arcoverde' as Municipio union all
	select 'PI' as Estado, 'Dom Expedito Lopes' as Municipio union all
	select 'PI' as Estado, 'Dom Inocêncio' as Municipio union all
	select 'PI' as Estado, 'Domingos Mourão' as Municipio union all
	select 'PI' as Estado, 'Elesbão Veloso' as Municipio union all
	select 'PI' as Estado, 'Eliseu Martins' as Municipio union all
	select 'PI' as Estado, 'Esperantina' as Municipio union all
	select 'PI' as Estado, 'Fartura do Piauí' as Municipio union all
	select 'PI' as Estado, 'Flores do Piauí' as Municipio union all
	select 'PI' as Estado, 'Floresta do Piauí' as Municipio union all
	select 'PI' as Estado, 'Floriano' as Municipio union all
	select 'PI' as Estado, 'Francinópolis' as Municipio union all
	select 'PI' as Estado, 'Francisco Ayres' as Municipio union all
	select 'PI' as Estado, 'Francisco Macedo' as Municipio union all
	select 'PI' as Estado, 'Francisco Santos' as Municipio union all
	select 'PI' as Estado, 'Fronteiras' as Municipio union all
	select 'PI' as Estado, 'Geminiano' as Municipio union all
	select 'PI' as Estado, 'Gilbués' as Municipio union all
	select 'PI' as Estado, 'Guadalupe' as Municipio union all
	select 'PI' as Estado, 'Guaribas' as Municipio union all
	select 'PI' as Estado, 'Hugo Napoleão' as Municipio union all
	select 'PI' as Estado, 'Ilha Grande' as Municipio union all
	select 'PI' as Estado, 'Inhuma' as Municipio union all
	select 'PI' as Estado, 'Ipiranga do Piauí' as Municipio union all
	select 'PI' as Estado, 'Isaías Coelho' as Municipio union all
	select 'PI' as Estado, 'Itainópolis' as Municipio union all
	select 'PI' as Estado, 'Itaueira' as Municipio union all
	select 'PI' as Estado, 'Jacobina do Piauí' as Municipio union all
	select 'PI' as Estado, 'Jaicós' as Municipio union all
	select 'PI' as Estado, 'Jardim do Mulato' as Municipio union all
	select 'PI' as Estado, 'Jatobá do Piauí' as Municipio union all
	select 'PI' as Estado, 'Jerumenha' as Municipio union all
	select 'PI' as Estado, 'João Costa' as Municipio union all
	select 'PI' as Estado, 'Joaquim Pires' as Municipio union all
	select 'PI' as Estado, 'Joca Marques' as Municipio union all
	select 'PI' as Estado, 'José de Freitas' as Municipio union all
	select 'PI' as Estado, 'Juazeiro do Piauí' as Municipio union all
	select 'PI' as Estado, 'Júlio Borges' as Municipio union all
	select 'PI' as Estado, 'Jurema' as Municipio union all
	select 'PI' as Estado, 'Lagoa Alegre' as Municipio union all
	select 'PI' as Estado, 'Lagoa de São Francisco' as Municipio union all
	select 'PI' as Estado, 'Lagoa do Barro do Piauí' as Municipio union all
	select 'PI' as Estado, 'Lagoa do Piauí' as Municipio union all
	select 'PI' as Estado, 'Lagoa do Sítio' as Municipio union all
	select 'PI' as Estado, 'Lagoinha do Piauí' as Municipio union all
	select 'PI' as Estado, 'Landri Sales' as Municipio union all
	select 'PI' as Estado, 'Luís Correia' as Municipio union all
	select 'PI' as Estado, 'Luzilândia' as Municipio union all
	select 'PI' as Estado, 'Madeiro' as Municipio union all
	select 'PI' as Estado, 'Manoel Emídio' as Municipio union all
	select 'PI' as Estado, 'Marcolândia' as Municipio union all
	select 'PI' as Estado, 'Marcos Parente' as Municipio union all
	select 'PI' as Estado, 'Massapê do Piauí' as Municipio union all
	select 'PI' as Estado, 'Matias Olímpio' as Municipio union all
	select 'PI' as Estado, 'Miguel Alves' as Municipio union all
	select 'PI' as Estado, 'Miguel Leão' as Municipio union all
	select 'PI' as Estado, 'Milton Brandão' as Municipio union all
	select 'PI' as Estado, 'Monsenhor Gil' as Municipio union all
	select 'PI' as Estado, 'Monsenhor Hipólito' as Municipio union all
	select 'PI' as Estado, 'Monte Alegre do Piauí' as Municipio union all
	select 'PI' as Estado, 'Morro Cabeça no Tempo' as Municipio union all
	select 'PI' as Estado, 'Morro do Chapéu do Piauí' as Municipio union all
	select 'PI' as Estado, 'Murici dos Portelas' as Municipio union all
	select 'PI' as Estado, 'Nazaré do Piauí' as Municipio union all
	select 'PI' as Estado, 'Nossa Senhora de Nazaré' as Municipio union all
	select 'PI' as Estado, 'Nossa Senhora dos Remédios' as Municipio union all
	select 'PI' as Estado, 'Nova Santa Rita' as Municipio union all
	select 'PI' as Estado, 'Novo Oriente do Piauí' as Municipio union all
	select 'PI' as Estado, 'Novo Santo Antônio' as Municipio union all
	select 'PI' as Estado, 'Oeiras' as Municipio union all
	select 'PI' as Estado, 'Olho D''Água do Piauí' as Municipio union all
	select 'PI' as Estado, 'Padre Marcos' as Municipio union all
	select 'PI' as Estado, 'Paes Landim' as Municipio union all
	select 'PI' as Estado, 'Pajeú do Piauí' as Municipio union all
	select 'PI' as Estado, 'Palmeira do Piauí' as Municipio union all
	select 'PI' as Estado, 'Palmeirais' as Municipio union all
	select 'PI' as Estado, 'Paquetá' as Municipio union all
	select 'PI' as Estado, 'Parnaguá' as Municipio union all
	select 'PI' as Estado, 'Parnaíba' as Municipio union all
	select 'PI' as Estado, 'Passagem Franca do Piauí' as Municipio union all
	select 'PI' as Estado, 'Patos do Piauí' as Municipio union all
	select 'PI' as Estado, 'Pau D''Arco do Piauí' as Municipio union all
	select 'PI' as Estado, 'Paulistana' as Municipio union all
	select 'PI' as Estado, 'Pavussu' as Municipio union all
	select 'PI' as Estado, 'Pedro II' as Municipio union all
	select 'PI' as Estado, 'Pedro Laurentino' as Municipio union all
	select 'PI' as Estado, 'Picos' as Municipio union all
	select 'PI' as Estado, 'Pimenteiras' as Municipio union all
	select 'PI' as Estado, 'Pio IX' as Municipio union all
	select 'PI' as Estado, 'Piracuruca' as Municipio union all
	select 'PI' as Estado, 'Piripiri' as Municipio union all
	select 'PI' as Estado, 'Porto' as Municipio union all
	select 'PI' as Estado, 'Porto Alegre do Piauí' as Municipio union all
	select 'PI' as Estado, 'Prata do Piauí' as Municipio union all
	select 'PI' as Estado, 'Queimada Nova' as Municipio union all
	select 'PI' as Estado, 'Redenção do Gurguéia' as Municipio union all
	select 'PI' as Estado, 'Regeneração' as Municipio union all
	select 'PI' as Estado, 'Riacho Frio' as Municipio union all
	select 'PI' as Estado, 'Ribeira do Piauí' as Municipio union all
	select 'PI' as Estado, 'Ribeiro Gonçalves' as Municipio union all
	select 'PI' as Estado, 'Rio Grande do Piauí' as Municipio union all
	select 'PI' as Estado, 'Santa Cruz do Piauí' as Municipio union all
	select 'PI' as Estado, 'Santa Cruz dos Milagres' as Municipio union all
	select 'PI' as Estado, 'Santa Filomena' as Municipio union all
	select 'PI' as Estado, 'Santa Luz' as Municipio union all
	select 'PI' as Estado, 'Santa Rosa do Piauí' as Municipio union all
	select 'PI' as Estado, 'Santana do Piauí' as Municipio union all
	select 'PI' as Estado, 'Santo Antônio de Lisboa' as Municipio union all
	select 'PI' as Estado, 'Santo Antônio dos Milagres' as Municipio union all
	select 'PI' as Estado, 'Santo Inácio do Piauí' as Municipio union all
	select 'PI' as Estado, 'São Braz do Piauí' as Municipio union all
	select 'PI' as Estado, 'São Félix do Piauí' as Municipio union all
	select 'PI' as Estado, 'São Francisco de Assis do Piauí' as Municipio union all
	select 'PI' as Estado, 'São Francisco do Piauí' as Municipio union all
	select 'PI' as Estado, 'São Gonçalo do Gurguéia' as Municipio union all
	select 'PI' as Estado, 'São Gonçalo do Piauí' as Municipio union all
	select 'PI' as Estado, 'São João da Canabrava' as Municipio union all
	select 'PI' as Estado, 'São João da Fronteira' as Municipio union all
	select 'PI' as Estado, 'São João da Serra' as Municipio union all
	select 'PI' as Estado, 'São João da Varjota' as Municipio union all
	select 'PI' as Estado, 'São João do Arraial' as Municipio union all
	select 'PI' as Estado, 'São João do Piauí' as Municipio union all
	select 'PI' as Estado, 'São José do Divino' as Municipio union all
	select 'PI' as Estado, 'São José do Peixe' as Municipio union all
	select 'PI' as Estado, 'São José do Piauí' as Municipio union all
	select 'PI' as Estado, 'São Julião' as Municipio union all
	select 'PI' as Estado, 'São Lourenço do Piauí' as Municipio union all
	select 'PI' as Estado, 'São Luis do Piauí' as Municipio union all
	select 'PI' as Estado, 'São Miguel da Baixa Grande' as Municipio union all
	select 'PI' as Estado, 'São Miguel do Fidalgo' as Municipio union all
	select 'PI' as Estado, 'São Miguel do Tapuio' as Municipio union all
	select 'PI' as Estado, 'São Pedro do Piauí' as Municipio union all
	select 'PI' as Estado, 'São Raimundo Nonato' as Municipio union all
	select 'PI' as Estado, 'Sebastião Barros' as Municipio union all
	select 'PI' as Estado, 'Sebastião Leal' as Municipio union all
	select 'PI' as Estado, 'Sigefredo Pacheco' as Municipio union all
	select 'PI' as Estado, 'Simões' as Municipio union all
	select 'PI' as Estado, 'Simplício Mendes' as Municipio union all
	select 'PI' as Estado, 'Socorro do Piauí' as Municipio union all
	select 'PI' as Estado, 'Sussuapara' as Municipio union all
	select 'PI' as Estado, 'Tamboril do Piauí' as Municipio union all
	select 'PI' as Estado, 'Tanque do Piauí' as Municipio union all
	select 'PI' as Estado, 'Teresina' as Municipio union all
	select 'PI' as Estado, 'União' as Municipio union all
	select 'PI' as Estado, 'Uruçuí' as Municipio union all
	select 'PI' as Estado, 'Valença do Piauí' as Municipio union all
	select 'PI' as Estado, 'Várzea Branca' as Municipio union all
	select 'PI' as Estado, 'Várzea Grande' as Municipio union all
	select 'PI' as Estado, 'Vera Mendes' as Municipio union all
	select 'PI' as Estado, 'Vila Nova do Piauí' as Municipio union all
	select 'PI' as Estado, 'Wall Ferraz' as Municipio union all
	select 'CE' as Estado, 'Abaiara' as Municipio union all
	select 'CE' as Estado, 'Acarape' as Municipio union all
	select 'CE' as Estado, 'Acaraú' as Municipio union all
	select 'CE' as Estado, 'Acopiara' as Municipio union all
	select 'CE' as Estado, 'Aiuaba' as Municipio union all
	select 'CE' as Estado, 'Alcântaras' as Municipio union all
	select 'CE' as Estado, 'Altaneira' as Municipio union all
	select 'CE' as Estado, 'Alto Santo' as Municipio union all
	select 'CE' as Estado, 'Amontada' as Municipio union all
	select 'CE' as Estado, 'Antonina do Norte' as Municipio union all
	select 'CE' as Estado, 'Apuiarés' as Municipio union all
	select 'CE' as Estado, 'Aquiraz' as Municipio union all
	select 'CE' as Estado, 'Aracati' as Municipio union all
	select 'CE' as Estado, 'Aracoiaba' as Municipio union all
	select 'CE' as Estado, 'Ararendá' as Municipio union all
	select 'CE' as Estado, 'Araripe' as Municipio union all
	select 'CE' as Estado, 'Aratuba' as Municipio union all
	select 'CE' as Estado, 'Arneiroz' as Municipio union all
	select 'CE' as Estado, 'Assaré' as Municipio union all
	select 'CE' as Estado, 'Aurora' as Municipio union all
	select 'CE' as Estado, 'Baixio' as Municipio union all
	select 'CE' as Estado, 'Banabuiú' as Municipio union all
	select 'CE' as Estado, 'Barbalha' as Municipio union all
	select 'CE' as Estado, 'Barreira' as Municipio union all
	select 'CE' as Estado, 'Barro' as Municipio union all
	select 'CE' as Estado, 'Barroquinha' as Municipio union all
	select 'CE' as Estado, 'Baturité' as Municipio union all
	select 'CE' as Estado, 'Beberibe' as Municipio union all
	select 'CE' as Estado, 'Bela Cruz' as Municipio union all
	select 'CE' as Estado, 'Boa Viagem' as Municipio union all
	select 'CE' as Estado, 'Brejo Santo' as Municipio union all
	select 'CE' as Estado, 'Camocim' as Municipio union all
	select 'CE' as Estado, 'Campos Sales' as Municipio union all
	select 'CE' as Estado, 'Canindé' as Municipio union all
	select 'CE' as Estado, 'Capistrano' as Municipio union all
	select 'CE' as Estado, 'Caridade' as Municipio union all
	select 'CE' as Estado, 'Cariré' as Municipio union all
	select 'CE' as Estado, 'Caririaçu' as Municipio union all
	select 'CE' as Estado, 'Cariús' as Municipio union all
	select 'CE' as Estado, 'Carnaubal' as Municipio union all
	select 'CE' as Estado, 'Cascavel' as Municipio union all
	select 'CE' as Estado, 'Catarina' as Municipio union all
	select 'CE' as Estado, 'Catunda' as Municipio union all
	select 'CE' as Estado, 'Caucaia' as Municipio union all
	select 'CE' as Estado, 'Cedro' as Municipio union all
	select 'CE' as Estado, 'Chaval' as Municipio union all
	select 'CE' as Estado, 'Choró' as Municipio union all
	select 'CE' as Estado, 'Chorozinho' as Municipio union all
	select 'CE' as Estado, 'Coreaú' as Municipio union all
	select 'CE' as Estado, 'Crateús' as Municipio union all
	select 'CE' as Estado, 'Crato' as Municipio union all
	select 'CE' as Estado, 'Croatá' as Municipio union all
	select 'CE' as Estado, 'Cruz' as Municipio union all
	select 'CE' as Estado, 'Deputado Irapuan Pinheiro' as Municipio union all
	select 'CE' as Estado, 'Ererê' as Municipio union all
	select 'CE' as Estado, 'Eusébio' as Municipio union all
	select 'CE' as Estado, 'Farias Brito' as Municipio union all
	select 'CE' as Estado, 'Forquilha' as Municipio union all
	select 'CE' as Estado, 'Fortaleza' as Municipio union all
	select 'CE' as Estado, 'Fortim' as Municipio union all
	select 'CE' as Estado, 'Frecheirinha' as Municipio union all
	select 'CE' as Estado, 'General Sampaio' as Municipio union all
	select 'CE' as Estado, 'Graça' as Municipio union all
	select 'CE' as Estado, 'Granja' as Municipio union all
	select 'CE' as Estado, 'Granjeiro' as Municipio union all
	select 'CE' as Estado, 'Groaíras' as Municipio union all
	select 'CE' as Estado, 'Guaiúba' as Municipio union all
	select 'CE' as Estado, 'Guaraciaba do Norte' as Municipio union all
	select 'CE' as Estado, 'Guaramiranga' as Municipio union all
	select 'CE' as Estado, 'Hidrolândia' as Municipio union all
	select 'CE' as Estado, 'Horizonte' as Municipio union all
	select 'CE' as Estado, 'Ibaretama' as Municipio union all
	select 'CE' as Estado, 'Ibiapina' as Municipio union all
	select 'CE' as Estado, 'Ibicuitinga' as Municipio union all
	select 'CE' as Estado, 'Icapuí' as Municipio union all
	select 'CE' as Estado, 'Icó' as Municipio union all
	select 'CE' as Estado, 'Iguatu' as Municipio union all
	select 'CE' as Estado, 'Independência' as Municipio union all
	select 'CE' as Estado, 'Ipaporanga' as Municipio union all
	select 'CE' as Estado, 'Ipaumirim' as Municipio union all
	select 'CE' as Estado, 'Ipu' as Municipio union all
	select 'CE' as Estado, 'Ipueiras' as Municipio union all
	select 'CE' as Estado, 'Iracema' as Municipio union all
	select 'CE' as Estado, 'Irauçuba' as Municipio union all
	select 'CE' as Estado, 'Itaiçaba' as Municipio union all
	select 'CE' as Estado, 'Itaitinga' as Municipio union all
	select 'CE' as Estado, 'Itapagé' as Municipio union all
	select 'CE' as Estado, 'Itapipoca' as Municipio union all
	select 'CE' as Estado, 'Itapiúna' as Municipio union all
	select 'CE' as Estado, 'Itarema' as Municipio union all
	select 'CE' as Estado, 'Itatira' as Municipio union all
	select 'CE' as Estado, 'Jaguaretama' as Municipio union all
	select 'CE' as Estado, 'Jaguaribara' as Municipio union all
	select 'CE' as Estado, 'Jaguaribe' as Municipio union all
	select 'CE' as Estado, 'Jaguaruana' as Municipio union all
	select 'CE' as Estado, 'Jardim' as Municipio union all
	select 'CE' as Estado, 'Jati' as Municipio union all
	select 'CE' as Estado, 'Jijoca de Jericoacoara' as Municipio union all
	select 'CE' as Estado, 'Juazeiro do Norte' as Municipio union all
	select 'CE' as Estado, 'Jucás' as Municipio union all
	select 'CE' as Estado, 'Lavras da Mangabeira' as Municipio union all
	select 'CE' as Estado, 'Limoeiro do Norte' as Municipio union all
	select 'CE' as Estado, 'Madalena' as Municipio union all
	select 'CE' as Estado, 'Maracanaú' as Municipio union all
	select 'CE' as Estado, 'Maranguape' as Municipio union all
	select 'CE' as Estado, 'Marco' as Municipio union all
	select 'CE' as Estado, 'Martinópole' as Municipio union all
	select 'CE' as Estado, 'Massapê' as Municipio union all
	select 'CE' as Estado, 'Mauriti' as Municipio union all
	select 'CE' as Estado, 'Meruoca' as Municipio union all
	select 'CE' as Estado, 'Milagres' as Municipio union all
	select 'CE' as Estado, 'Milhã' as Municipio union all
	select 'CE' as Estado, 'Miraíma' as Municipio union all
	select 'CE' as Estado, 'Missão Velha' as Municipio union all
	select 'CE' as Estado, 'Mombaça' as Municipio union all
	select 'CE' as Estado, 'Monsenhor Tabosa' as Municipio union all
	select 'CE' as Estado, 'Morada Nova' as Municipio union all
	select 'CE' as Estado, 'Moraújo' as Municipio union all
	select 'CE' as Estado, 'Morrinhos' as Municipio union all
	select 'CE' as Estado, 'Mucambo' as Municipio union all
	select 'CE' as Estado, 'Mulungu' as Municipio union all
	select 'CE' as Estado, 'Nova Olinda' as Municipio union all
	select 'CE' as Estado, 'Nova Russas' as Municipio union all
	select 'CE' as Estado, 'Novo Oriente' as Municipio union all
	select 'CE' as Estado, 'Ocara' as Municipio union all
	select 'CE' as Estado, 'Orós' as Municipio union all
	select 'CE' as Estado, 'Pacajus' as Municipio union all
	select 'CE' as Estado, 'Pacatuba' as Municipio union all
	select 'CE' as Estado, 'Pacoti' as Municipio union all
	select 'CE' as Estado, 'Pacujá' as Municipio union all
	select 'CE' as Estado, 'Palhano' as Municipio union all
	select 'CE' as Estado, 'Palmácia' as Municipio union all
	select 'CE' as Estado, 'Paracuru' as Municipio union all
	select 'CE' as Estado, 'Paraipaba' as Municipio union all
	select 'CE' as Estado, 'Parambu' as Municipio union all
	select 'CE' as Estado, 'Paramoti' as Municipio union all
	select 'CE' as Estado, 'Pedra Branca' as Municipio union all
	select 'CE' as Estado, 'Penaforte' as Municipio union all
	select 'CE' as Estado, 'Pentecoste' as Municipio union all
	select 'CE' as Estado, 'Pereiro' as Municipio union all
	select 'CE' as Estado, 'Pindoretama' as Municipio union all
	select 'CE' as Estado, 'Piquet Carneiro' as Municipio union all
	select 'CE' as Estado, 'Pires Ferreira' as Municipio union all
	select 'CE' as Estado, 'Poranga' as Municipio union all
	select 'CE' as Estado, 'Porteiras' as Municipio union all
	select 'CE' as Estado, 'Potengi' as Municipio union all
	select 'CE' as Estado, 'Potiretama' as Municipio union all
	select 'CE' as Estado, 'Quiterianópolis' as Municipio union all
	select 'CE' as Estado, 'Quixadá' as Municipio union all
	select 'CE' as Estado, 'Quixelô' as Municipio union all
	select 'CE' as Estado, 'Quixeramobim' as Municipio union all
	select 'CE' as Estado, 'Quixeré' as Municipio union all
	select 'CE' as Estado, 'Redenção' as Municipio union all
	select 'CE' as Estado, 'Reriutaba' as Municipio union all
	select 'CE' as Estado, 'Russas' as Municipio union all
	select 'CE' as Estado, 'Saboeiro' as Municipio union all
	select 'CE' as Estado, 'Salitre' as Municipio union all
	select 'CE' as Estado, 'Santa Quitéria' as Municipio union all
	select 'CE' as Estado, 'Santana do Acaraú' as Municipio union all
	select 'CE' as Estado, 'Santana do Cariri' as Municipio union all
	select 'CE' as Estado, 'São Benedito' as Municipio union all
	select 'CE' as Estado, 'São Gonçalo do Amarante' as Municipio union all
	select 'CE' as Estado, 'São João do Jaguaribe' as Municipio union all
	select 'CE' as Estado, 'São Luís do Curu' as Municipio union all
	select 'CE' as Estado, 'Senador Pompeu' as Municipio union all
	select 'CE' as Estado, 'Senador Sá' as Municipio union all
	select 'CE' as Estado, 'Sobral' as Municipio union all
	select 'CE' as Estado, 'Solonópole' as Municipio union all
	select 'CE' as Estado, 'Tabuleiro do Norte' as Municipio union all
	select 'CE' as Estado, 'Tamboril' as Municipio union all
	select 'CE' as Estado, 'Tarrafas' as Municipio union all
	select 'CE' as Estado, 'Tauá' as Municipio union all
	select 'CE' as Estado, 'Tejuçuoca' as Municipio union all
	select 'CE' as Estado, 'Tianguá' as Municipio union all
	select 'CE' as Estado, 'Trairi' as Municipio union all
	select 'CE' as Estado, 'Tururu' as Municipio union all
	select 'CE' as Estado, 'Ubajara' as Municipio union all
	select 'CE' as Estado, 'Umari' as Municipio union all
	select 'CE' as Estado, 'Umirim' as Municipio union all
	select 'CE' as Estado, 'Uruburetama' as Municipio union all
	select 'CE' as Estado, 'Uruoca' as Municipio union all
	select 'CE' as Estado, 'Varjota' as Municipio union all
	select 'CE' as Estado, 'Várzea Alegre' as Municipio union all
	select 'CE' as Estado, 'Viçosa do Ceará' as Municipio union all
	select 'RN' as Estado, 'Acari' as Municipio union all
	select 'RN' as Estado, 'Açu' as Municipio union all
	select 'RN' as Estado, 'Afonso Bezerra' as Municipio union all
	select 'RN' as Estado, 'Água Nova' as Municipio union all
	select 'RN' as Estado, 'Alexandria' as Municipio union all
	select 'RN' as Estado, 'Almino Afonso' as Municipio union all
	select 'RN' as Estado, 'Alto do Rodrigues' as Municipio union all
	select 'RN' as Estado, 'Angicos' as Municipio union all
	select 'RN' as Estado, 'Antônio Martins' as Municipio union all
	select 'RN' as Estado, 'Apodi' as Municipio union all
	select 'RN' as Estado, 'Areia Branca' as Municipio union all
	select 'RN' as Estado, 'Arês' as Municipio union all
	select 'RN' as Estado, 'Augusto Severo' as Municipio union all
	select 'RN' as Estado, 'Baía Formosa' as Municipio union all
	select 'RN' as Estado, 'Baraúna' as Municipio union all
	select 'RN' as Estado, 'Barcelona' as Municipio union all
	select 'RN' as Estado, 'Bento Fernandes' as Municipio union all
	select 'RN' as Estado, 'Bodó' as Municipio union all
	select 'RN' as Estado, 'Bom Jesus' as Municipio union all
	select 'RN' as Estado, 'Brejinho' as Municipio union all
	select 'RN' as Estado, 'Caiçara do Norte' as Municipio union all
	select 'RN' as Estado, 'Caiçara do Rio do Vento' as Municipio union all
	select 'RN' as Estado, 'Caicó' as Municipio union all
	select 'RN' as Estado, 'Campo Redondo' as Municipio union all
	select 'RN' as Estado, 'Canguaretama' as Municipio union all
	select 'RN' as Estado, 'Caraúbas' as Municipio union all
	select 'RN' as Estado, 'Carnaúba dos Dantas' as Municipio union all
	select 'RN' as Estado, 'Carnaubais' as Municipio union all
	select 'RN' as Estado, 'Ceará-Mirim' as Municipio union all
	select 'RN' as Estado, 'Cerro Corá' as Municipio union all
	select 'RN' as Estado, 'Coronel Ezequiel' as Municipio union all
	select 'RN' as Estado, 'Coronel João Pessoa' as Municipio union all
	select 'RN' as Estado, 'Cruzeta' as Municipio union all
	select 'RN' as Estado, 'Currais Novos' as Municipio union all
	select 'RN' as Estado, 'Doutor Severiano' as Municipio union all
	select 'RN' as Estado, 'Encanto' as Municipio union all
	select 'RN' as Estado, 'Equador' as Municipio union all
	select 'RN' as Estado, 'Espírito Santo' as Municipio union all
	select 'RN' as Estado, 'Extremoz' as Municipio union all
	select 'RN' as Estado, 'Felipe Guerra' as Municipio union all
	select 'RN' as Estado, 'Fernando Pedroza' as Municipio union all
	select 'RN' as Estado, 'Florânia' as Municipio union all
	select 'RN' as Estado, 'Francisco Dantas' as Municipio union all
	select 'RN' as Estado, 'Frutuoso Gomes' as Municipio union all
	select 'RN' as Estado, 'Galinhos' as Municipio union all
	select 'RN' as Estado, 'Goianinha' as Municipio union all
	select 'RN' as Estado, 'Governador Dix-Sept Rosado' as Municipio union all
	select 'RN' as Estado, 'Grossos' as Municipio union all
	select 'RN' as Estado, 'Guamaré' as Municipio union all
	select 'RN' as Estado, 'Ielmo Marinho' as Municipio union all
	select 'RN' as Estado, 'Ipanguaçu' as Municipio union all
	select 'RN' as Estado, 'Ipueira' as Municipio union all
	select 'RN' as Estado, 'Itajá' as Municipio union all
	select 'RN' as Estado, 'Itaú' as Municipio union all
	select 'RN' as Estado, 'Jaçanã' as Municipio union all
	select 'RN' as Estado, 'Jandaíra' as Municipio union all
	select 'RN' as Estado, 'Janduís' as Municipio union all
	select 'RN' as Estado, 'Januário Cicco' as Municipio union all
	select 'RN' as Estado, 'Japi' as Municipio union all
	select 'RN' as Estado, 'Jardim de Angicos' as Municipio union all
	select 'RN' as Estado, 'Jardim de Piranhas' as Municipio union all
	select 'RN' as Estado, 'Jardim do Seridó' as Municipio union all
	select 'RN' as Estado, 'João Câmara' as Municipio union all
	select 'RN' as Estado, 'João Dias' as Municipio union all
	select 'RN' as Estado, 'José da Penha' as Municipio union all
	select 'RN' as Estado, 'Jucurutu' as Municipio union all
	select 'RN' as Estado, 'Jundiá' as Municipio union all
	select 'RN' as Estado, 'Lagoa d''Anta' as Municipio union all
	select 'RN' as Estado, 'Lagoa de Pedras' as Municipio union all
	select 'RN' as Estado, 'Lagoa de Velhos' as Municipio union all
	select 'RN' as Estado, 'Lagoa Nova' as Municipio union all
	select 'RN' as Estado, 'Lagoa Salgada' as Municipio union all
	select 'RN' as Estado, 'Lajes' as Municipio union all
	select 'RN' as Estado, 'Lajes Pintadas' as Municipio union all
	select 'RN' as Estado, 'Lucrécia' as Municipio union all
	select 'RN' as Estado, 'Luís Gomes' as Municipio union all
	select 'RN' as Estado, 'Macaíba' as Municipio union all
	select 'RN' as Estado, 'Macau' as Municipio union all
	select 'RN' as Estado, 'Major Sales' as Municipio union all
	select 'RN' as Estado, 'Marcelino Vieira' as Municipio union all
	select 'RN' as Estado, 'Martins' as Municipio union all
	select 'RN' as Estado, 'Maxaranguape' as Municipio union all
	select 'RN' as Estado, 'Messias Targino' as Municipio union all
	select 'RN' as Estado, 'Montanhas' as Municipio union all
	select 'RN' as Estado, 'Monte Alegre' as Municipio union all
	select 'RN' as Estado, 'Monte das Gameleiras' as Municipio union all
	select 'RN' as Estado, 'Mossoró' as Municipio union all
	select 'RN' as Estado, 'Natal' as Municipio union all
	select 'RN' as Estado, 'Nísia Floresta' as Municipio union all
	select 'RN' as Estado, 'Nova Cruz' as Municipio union all
	select 'RN' as Estado, 'Olho-d''Água do Borges' as Municipio union all
	select 'RN' as Estado, 'Ouro Branco' as Municipio union all
	select 'RN' as Estado, 'Paraná' as Municipio union all
	select 'RN' as Estado, 'Paraú' as Municipio union all
	select 'RN' as Estado, 'Parazinho' as Municipio union all
	select 'RN' as Estado, 'Parelhas' as Municipio union all
	select 'RN' as Estado, 'Parnamirim' as Municipio union all
	select 'RN' as Estado, 'Passa e Fica' as Municipio union all
	select 'RN' as Estado, 'Passagem' as Municipio union all
	select 'RN' as Estado, 'Patu' as Municipio union all
	select 'RN' as Estado, 'Pau dos Ferros' as Municipio union all
	select 'RN' as Estado, 'Pedra Grande' as Municipio union all
	select 'RN' as Estado, 'Pedra Preta' as Municipio union all
	select 'RN' as Estado, 'Pedro Avelino' as Municipio union all
	select 'RN' as Estado, 'Pedro Velho' as Municipio union all
	select 'RN' as Estado, 'Pendências' as Municipio union all
	select 'RN' as Estado, 'Pilões' as Municipio union all
	select 'RN' as Estado, 'Poço Branco' as Municipio union all
	select 'RN' as Estado, 'Portalegre' as Municipio union all
	select 'RN' as Estado, 'Porto do Mangue' as Municipio union all
	select 'RN' as Estado, 'Presidente Juscelino' as Municipio union all
	select 'RN' as Estado, 'Pureza' as Municipio union all
	select 'RN' as Estado, 'Rafael Fernandes' as Municipio union all
	select 'RN' as Estado, 'Rafael Godeiro' as Municipio union all
	select 'RN' as Estado, 'Riacho da Cruz' as Municipio union all
	select 'RN' as Estado, 'Riacho de Santana' as Municipio union all
	select 'RN' as Estado, 'Riachuelo' as Municipio union all
	select 'RN' as Estado, 'Rio do Fogo' as Municipio union all
	select 'RN' as Estado, 'Rodolfo Fernandes' as Municipio union all
	select 'RN' as Estado, 'Ruy Barbosa' as Municipio union all
	select 'RN' as Estado, 'Santa Cruz' as Municipio union all
	select 'RN' as Estado, 'Santa Maria' as Municipio union all
	select 'RN' as Estado, 'Santana do Matos' as Municipio union all
	select 'RN' as Estado, 'Santana do Seridó' as Municipio union all
	select 'RN' as Estado, 'Santo Antônio' as Municipio union all
	select 'RN' as Estado, 'São Bento do Norte' as Municipio union all
	select 'RN' as Estado, 'São Bento do Trairí' as Municipio union all
	select 'RN' as Estado, 'São Fernando' as Municipio union all
	select 'RN' as Estado, 'São Francisco do Oeste' as Municipio union all
	select 'RN' as Estado, 'São Gonçalo do Amarante' as Municipio union all
	select 'RN' as Estado, 'São João do Sabugi' as Municipio union all
	select 'RN' as Estado, 'São José de Mipibu' as Municipio union all
	select 'RN' as Estado, 'São José do Campestre' as Municipio union all
	select 'RN' as Estado, 'São José do Seridó' as Municipio union all
	select 'RN' as Estado, 'São Miguel' as Municipio union all
	select 'RN' as Estado, 'São Miguel do Gostoso' as Municipio union all
	select 'RN' as Estado, 'São Paulo do Potengi' as Municipio union all
	select 'RN' as Estado, 'São Pedro' as Municipio union all
	select 'RN' as Estado, 'São Rafael' as Municipio union all
	select 'RN' as Estado, 'São Tomé' as Municipio union all
	select 'RN' as Estado, 'São Vicente' as Municipio union all
	select 'RN' as Estado, 'Senador Elói de Souza' as Municipio union all
	select 'RN' as Estado, 'Senador Georgino Avelino' as Municipio union all
	select 'RN' as Estado, 'Serra de São Bento' as Municipio union all
	select 'RN' as Estado, 'Serra do Mel' as Municipio union all
	select 'RN' as Estado, 'Serra Negra do Norte' as Municipio union all
	select 'RN' as Estado, 'Serrinha' as Municipio union all
	select 'RN' as Estado, 'Serrinha dos Pintos' as Municipio union all
	select 'RN' as Estado, 'Severiano Melo' as Municipio union all
	select 'RN' as Estado, 'Sítio Novo' as Municipio union all
	select 'RN' as Estado, 'Taboleiro Grande' as Municipio union all
	select 'RN' as Estado, 'Taipu' as Municipio union all
	select 'RN' as Estado, 'Tangará' as Municipio union all
	select 'RN' as Estado, 'Tenente Ananias' as Municipio union all
	select 'RN' as Estado, 'Tenente Laurentino Cruz' as Municipio union all
	select 'RN' as Estado, 'Tibau' as Municipio union all
	select 'RN' as Estado, 'Tibau do Sul' as Municipio union all
	select 'RN' as Estado, 'Timbaúba dos Batistas' as Municipio union all
	select 'RN' as Estado, 'Touros' as Municipio union all
	select 'RN' as Estado, 'Triunfo Potiguar' as Municipio union all
	select 'RN' as Estado, 'Umarizal' as Municipio union all
	select 'RN' as Estado, 'Upanema' as Municipio union all
	select 'RN' as Estado, 'Várzea' as Municipio union all
	select 'RN' as Estado, 'Venha-Ver' as Municipio union all
	select 'RN' as Estado, 'Vera Cruz' as Municipio union all
	select 'RN' as Estado, 'Viçosa' as Municipio union all
	select 'RN' as Estado, 'Vila Flor' as Municipio union all
	select 'PB' as Estado, 'Água Branca' as Municipio union all
	select 'PB' as Estado, 'Aguiar' as Municipio union all
	select 'PB' as Estado, 'Alagoa Grande' as Municipio union all
	select 'PB' as Estado, 'Alagoa Nova' as Municipio union all
	select 'PB' as Estado, 'Alagoinha' as Municipio union all
	select 'PB' as Estado, 'Alcantil' as Municipio union all
	select 'PB' as Estado, 'Algodão de Jandaíra' as Municipio union all
	select 'PB' as Estado, 'Alhandra' as Municipio union all
	select 'PB' as Estado, 'Amparo' as Municipio union all
	select 'PB' as Estado, 'Aparecida' as Municipio union all
	select 'PB' as Estado, 'Araçagi' as Municipio union all
	select 'PB' as Estado, 'Arara' as Municipio union all
	select 'PB' as Estado, 'Araruna' as Municipio union all
	select 'PB' as Estado, 'Areia' as Municipio union all
	select 'PB' as Estado, 'Areia de Baraúnas' as Municipio union all
	select 'PB' as Estado, 'Areial' as Municipio union all
	select 'PB' as Estado, 'Aroeiras' as Municipio union all
	select 'PB' as Estado, 'Assunção' as Municipio union all
	select 'PB' as Estado, 'Baía da Traição' as Municipio union all
	select 'PB' as Estado, 'Bananeiras' as Municipio union all
	select 'PB' as Estado, 'Baraúna' as Municipio union all
	select 'PB' as Estado, 'Barra de Santa Rosa' as Municipio union all
	select 'PB' as Estado, 'Barra de Santana' as Municipio union all
	select 'PB' as Estado, 'Barra de São Miguel' as Municipio union all
	select 'PB' as Estado, 'Bayeux' as Municipio union all
	select 'PB' as Estado, 'Belém' as Municipio union all
	select 'PB' as Estado, 'Belém do Brejo do Cruz' as Municipio union all
	select 'PB' as Estado, 'Bernardino Batista' as Municipio union all
	select 'PB' as Estado, 'Boa Ventura' as Municipio union all
	select 'PB' as Estado, 'Boa Vista' as Municipio union all
	select 'PB' as Estado, 'Bom Jesus' as Municipio union all
	select 'PB' as Estado, 'Bom Sucesso' as Municipio union all
	select 'PB' as Estado, 'Bonito de Santa Fé' as Municipio union all
	select 'PB' as Estado, 'Boqueirão' as Municipio union all
	select 'PB' as Estado, 'Borborema' as Municipio union all
	select 'PB' as Estado, 'Brejo do Cruz' as Municipio union all
	select 'PB' as Estado, 'Brejo dos Santos' as Municipio union all
	select 'PB' as Estado, 'Caaporã' as Municipio union all
	select 'PB' as Estado, 'Cabaceiras' as Municipio union all
	select 'PB' as Estado, 'Cabedelo' as Municipio union all
	select 'PB' as Estado, 'Cachoeira dos Índios' as Municipio union all
	select 'PB' as Estado, 'Cacimba de Areia' as Municipio union all
	select 'PB' as Estado, 'Cacimba de Dentro' as Municipio union all
	select 'PB' as Estado, 'Cacimbas' as Municipio union all
	select 'PB' as Estado, 'Caiçara' as Municipio union all
	select 'PB' as Estado, 'Cajazeiras' as Municipio union all
	select 'PB' as Estado, 'Cajazeirinhas' as Municipio union all
	select 'PB' as Estado, 'Caldas Brandão' as Municipio union all
	select 'PB' as Estado, 'Camalaú' as Municipio union all
	select 'PB' as Estado, 'Campina Grande' as Municipio union all
	select 'PB' as Estado, 'Campo de Santana' as Municipio union all
	select 'PB' as Estado, 'Capim' as Municipio union all
	select 'PB' as Estado, 'Caraúbas' as Municipio union all
	select 'PB' as Estado, 'Carrapateira' as Municipio union all
	select 'PB' as Estado, 'Casserengue' as Municipio union all
	select 'PB' as Estado, 'Catingueira' as Municipio union all
	select 'PB' as Estado, 'Catolé do Rocha' as Municipio union all
	select 'PB' as Estado, 'Caturité' as Municipio union all
	select 'PB' as Estado, 'Conceição' as Municipio union all
	select 'PB' as Estado, 'Condado' as Municipio union all
	select 'PB' as Estado, 'Conde' as Municipio union all
	select 'PB' as Estado, 'Congo' as Municipio union all
	select 'PB' as Estado, 'Coremas' as Municipio union all
	select 'PB' as Estado, 'Coxixola' as Municipio union all
	select 'PB' as Estado, 'Cruz do Espírito Santo' as Municipio union all
	select 'PB' as Estado, 'Cubati' as Municipio union all
	select 'PB' as Estado, 'Cuité' as Municipio union all
	select 'PB' as Estado, 'Cuité de Mamanguape' as Municipio union all
	select 'PB' as Estado, 'Cuitegi' as Municipio union all
	select 'PB' as Estado, 'Curral de Cima' as Municipio union all
	select 'PB' as Estado, 'Curral Velho' as Municipio union all
	select 'PB' as Estado, 'Damião' as Municipio union all
	select 'PB' as Estado, 'Desterro' as Municipio union all
	select 'PB' as Estado, 'Diamante' as Municipio union all
	select 'PB' as Estado, 'Dona Inês' as Municipio union all
	select 'PB' as Estado, 'Duas Estradas' as Municipio union all
	select 'PB' as Estado, 'Emas' as Municipio union all
	select 'PB' as Estado, 'Esperança' as Municipio union all
	select 'PB' as Estado, 'Fagundes' as Municipio union all
	select 'PB' as Estado, 'Frei Martinho' as Municipio union all
	select 'PB' as Estado, 'Gado Bravo' as Municipio union all
	select 'PB' as Estado, 'Guarabira' as Municipio union all
	select 'PB' as Estado, 'Gurinhém' as Municipio union all
	select 'PB' as Estado, 'Gurjão' as Municipio union all
	select 'PB' as Estado, 'Ibiara' as Municipio union all
	select 'PB' as Estado, 'Igaracy' as Municipio union all
	select 'PB' as Estado, 'Imaculada' as Municipio union all
	select 'PB' as Estado, 'Ingá' as Municipio union all
	select 'PB' as Estado, 'Itabaiana' as Municipio union all
	select 'PB' as Estado, 'Itaporanga' as Municipio union all
	select 'PB' as Estado, 'Itapororoca' as Municipio union all
	select 'PB' as Estado, 'Itatuba' as Municipio union all
	select 'PB' as Estado, 'Jacaraú' as Municipio union all
	select 'PB' as Estado, 'Jericó' as Municipio union all
	select 'PB' as Estado, 'João Pessoa' as Municipio union all
	select 'PB' as Estado, 'Juarez Távora' as Municipio union all
	select 'PB' as Estado, 'Juazeirinho' as Municipio union all
	select 'PB' as Estado, 'Junco do Seridó' as Municipio union all
	select 'PB' as Estado, 'Juripiranga' as Municipio union all
	select 'PB' as Estado, 'Juru' as Municipio union all
	select 'PB' as Estado, 'Lagoa' as Municipio union all
	select 'PB' as Estado, 'Lagoa de Dentro' as Municipio union all
	select 'PB' as Estado, 'Lagoa Seca' as Municipio union all
	select 'PB' as Estado, 'Lastro' as Municipio union all
	select 'PB' as Estado, 'Livramento' as Municipio union all
	select 'PB' as Estado, 'Logradouro' as Municipio union all
	select 'PB' as Estado, 'Lucena' as Municipio union all
	select 'PB' as Estado, 'Mãe d''Água' as Municipio union all
	select 'PB' as Estado, 'Malta' as Municipio union all
	select 'PB' as Estado, 'Mamanguape' as Municipio union all
	select 'PB' as Estado, 'Manaíra' as Municipio union all
	select 'PB' as Estado, 'Marcação' as Municipio union all
	select 'PB' as Estado, 'Mari' as Municipio union all
	select 'PB' as Estado, 'Marizópolis' as Municipio union all
	select 'PB' as Estado, 'Massaranduba' as Municipio union all
	select 'PB' as Estado, 'Mataraca' as Municipio union all
	select 'PB' as Estado, 'Matinhas' as Municipio union all
	select 'PB' as Estado, 'Mato Grosso' as Municipio union all
	select 'PB' as Estado, 'Maturéia' as Municipio union all
	select 'PB' as Estado, 'Mogeiro' as Municipio union all
	select 'PB' as Estado, 'Montadas' as Municipio union all
	select 'PB' as Estado, 'Monte Horebe' as Municipio union all
	select 'PB' as Estado, 'Monteiro' as Municipio union all
	select 'PB' as Estado, 'Mulungu' as Municipio union all
	select 'PB' as Estado, 'Natuba' as Municipio union all
	select 'PB' as Estado, 'Nazarezinho' as Municipio union all
	select 'PB' as Estado, 'Nova Floresta' as Municipio union all
	select 'PB' as Estado, 'Nova Olinda' as Municipio union all
	select 'PB' as Estado, 'Nova Palmeira' as Municipio union all
	select 'PB' as Estado, 'Olho d''Água' as Municipio union all
	select 'PB' as Estado, 'Olivedos' as Municipio union all
	select 'PB' as Estado, 'Ouro Velho' as Municipio union all
	select 'PB' as Estado, 'Parari' as Municipio union all
	select 'PB' as Estado, 'Passagem' as Municipio union all
	select 'PB' as Estado, 'Patos' as Municipio union all
	select 'PB' as Estado, 'Paulista' as Municipio union all
	select 'PB' as Estado, 'Pedra Branca' as Municipio union all
	select 'PB' as Estado, 'Pedra Lavrada' as Municipio union all
	select 'PB' as Estado, 'Pedras de Fogo' as Municipio union all
	select 'PB' as Estado, 'Pedro Régis' as Municipio union all
	select 'PB' as Estado, 'Piancó' as Municipio union all
	select 'PB' as Estado, 'Picuí' as Municipio union all
	select 'PB' as Estado, 'Pilar' as Municipio union all
	select 'PB' as Estado, 'Pilões' as Municipio union all
	select 'PB' as Estado, 'Pilõezinhos' as Municipio union all
	select 'PB' as Estado, 'Pirpirituba' as Municipio union all
	select 'PB' as Estado, 'Pitimbu' as Municipio union all
	select 'PB' as Estado, 'Pocinhos' as Municipio union all
	select 'PB' as Estado, 'Poço Dantas' as Municipio union all
	select 'PB' as Estado, 'Poço de José de Moura' as Municipio union all
	select 'PB' as Estado, 'Pombal' as Municipio union all
	select 'PB' as Estado, 'Prata' as Municipio union all
	select 'PB' as Estado, 'Princesa Isabel' as Municipio union all
	select 'PB' as Estado, 'Puxinanã' as Municipio union all
	select 'PB' as Estado, 'Queimadas' as Municipio union all
	select 'PB' as Estado, 'Quixabá' as Municipio union all
	select 'PB' as Estado, 'Remígio' as Municipio union all
	select 'PB' as Estado, 'Riachão' as Municipio union all
	select 'PB' as Estado, 'Riachão do Bacamarte' as Municipio union all
	select 'PB' as Estado, 'Riachão do Poço' as Municipio union all
	select 'PB' as Estado, 'Riacho de Santo Antônio' as Municipio union all
	select 'PB' as Estado, 'Riacho dos Cavalos' as Municipio union all
	select 'PB' as Estado, 'Rio Tinto' as Municipio union all
	select 'PB' as Estado, 'Salgadinho' as Municipio union all
	select 'PB' as Estado, 'Salgado de São Félix' as Municipio union all
	select 'PB' as Estado, 'Santa Cecília' as Municipio union all
	select 'PB' as Estado, 'Santa Cruz' as Municipio union all
	select 'PB' as Estado, 'Santa Helena' as Municipio union all
	select 'PB' as Estado, 'Santa Inês' as Municipio union all
	select 'PB' as Estado, 'Santa Luzia' as Municipio union all
	select 'PB' as Estado, 'Santa Rita' as Municipio union all
	select 'PB' as Estado, 'Santa Teresinha' as Municipio union all
	select 'PB' as Estado, 'Santana de Mangueira' as Municipio union all
	select 'PB' as Estado, 'Santana dos Garrotes' as Municipio union all
	select 'PB' as Estado, 'Santarém' as Municipio union all
	select 'PB' as Estado, 'Santo André' as Municipio union all
	select 'PB' as Estado, 'São Bentinho' as Municipio union all
	select 'PB' as Estado, 'São Bento' as Municipio union all
	select 'PB' as Estado, 'São Domingos de Pombal' as Municipio union all
	select 'PB' as Estado, 'São Domingos do Cariri' as Municipio union all
	select 'PB' as Estado, 'São Francisco' as Municipio union all
	select 'PB' as Estado, 'São João do Cariri' as Municipio union all
	select 'PB' as Estado, 'São João do Rio do Peixe' as Municipio union all
	select 'PB' as Estado, 'São João do Tigre' as Municipio union all
	select 'PB' as Estado, 'São José da Lagoa Tapada' as Municipio union all
	select 'PB' as Estado, 'São José de Caiana' as Municipio union all
	select 'PB' as Estado, 'São José de Espinharas' as Municipio union all
	select 'PB' as Estado, 'São José de Piranhas' as Municipio union all
	select 'PB' as Estado, 'São José de Princesa' as Municipio union all
	select 'PB' as Estado, 'São José do Bonfim' as Municipio union all
	select 'PB' as Estado, 'São José do Brejo do Cruz' as Municipio union all
	select 'PB' as Estado, 'São José do Sabugi' as Municipio union all
	select 'PB' as Estado, 'São José dos Cordeiros' as Municipio union all
	select 'PB' as Estado, 'São José dos Ramos' as Municipio union all
	select 'PB' as Estado, 'São Mamede' as Municipio union all
	select 'PB' as Estado, 'São Miguel de Taipu' as Municipio union all
	select 'PB' as Estado, 'São Sebastião de Lagoa de Roça' as Municipio union all
	select 'PB' as Estado, 'São Sebastião do Umbuzeiro' as Municipio union all
	select 'PB' as Estado, 'Sapé' as Municipio union all
	select 'PB' as Estado, 'Seridó' as Municipio union all
	select 'PB' as Estado, 'Serra Branca' as Municipio union all
	select 'PB' as Estado, 'Serra da Raiz' as Municipio union all
	select 'PB' as Estado, 'Serra Grande' as Municipio union all
	select 'PB' as Estado, 'Serra Redonda' as Municipio union all
	select 'PB' as Estado, 'Serraria' as Municipio union all
	select 'PB' as Estado, 'Sertãozinho' as Municipio union all
	select 'PB' as Estado, 'Sobrado' as Municipio union all
	select 'PB' as Estado, 'Solânea' as Municipio union all
	select 'PB' as Estado, 'Soledade' as Municipio union all
	select 'PB' as Estado, 'Sossêgo' as Municipio union all
	select 'PB' as Estado, 'Sousa' as Municipio union all
	select 'PB' as Estado, 'Sumé' as Municipio union all
	select 'PB' as Estado, 'Taperoá' as Municipio union all
	select 'PB' as Estado, 'Tavares' as Municipio union all
	select 'PB' as Estado, 'Teixeira' as Municipio union all
	select 'PB' as Estado, 'Tenório' as Municipio union all
	select 'PB' as Estado, 'Triunfo' as Municipio union all
	select 'PB' as Estado, 'Uiraúna' as Municipio union all
	select 'PB' as Estado, 'Umbuzeiro' as Municipio union all
	select 'PB' as Estado, 'Várzea' as Municipio union all
	select 'PB' as Estado, 'Vieirópolis' as Municipio union all
	select 'PB' as Estado, 'Vista Serrana' as Municipio union all
	select 'PB' as Estado, 'Zabelê' as Municipio union all
	select 'PE' as Estado, 'Abreu e Lima' as Municipio union all
	select 'PE' as Estado, 'Afogados da Ingazeira' as Municipio union all
	select 'PE' as Estado, 'Afrânio' as Municipio union all
	select 'PE' as Estado, 'Agrestina' as Municipio union all
	select 'PE' as Estado, 'Água Preta' as Municipio union all
	select 'PE' as Estado, 'Águas Belas' as Municipio union all
	select 'PE' as Estado, 'Alagoinha' as Municipio union all
	select 'PE' as Estado, 'Aliança' as Municipio union all
	select 'PE' as Estado, 'Altinho' as Municipio union all
	select 'PE' as Estado, 'Amaraji' as Municipio union all
	select 'PE' as Estado, 'Angelim' as Municipio union all
	select 'PE' as Estado, 'Araçoiaba' as Municipio union all
	select 'PE' as Estado, 'Araripina' as Municipio union all
	select 'PE' as Estado, 'Arcoverde' as Municipio union all
	select 'PE' as Estado, 'Barra de Guabiraba' as Municipio union all
	select 'PE' as Estado, 'Barreiros' as Municipio union all
	select 'PE' as Estado, 'Belém de Maria' as Municipio union all
	select 'PE' as Estado, 'Belém de São Francisco' as Municipio union all
	select 'PE' as Estado, 'Belo Jardim' as Municipio union all
	select 'PE' as Estado, 'Betânia' as Municipio union all
	select 'PE' as Estado, 'Bezerros' as Municipio union all
	select 'PE' as Estado, 'Bodocó' as Municipio union all
	select 'PE' as Estado, 'Bom Conselho' as Municipio union all
	select 'PE' as Estado, 'Bom Jardim' as Municipio union all
	select 'PE' as Estado, 'Bonito' as Municipio union all
	select 'PE' as Estado, 'Brejão' as Municipio union all
	select 'PE' as Estado, 'Brejinho' as Municipio union all
	select 'PE' as Estado, 'Brejo da Madre de Deus' as Municipio union all
	select 'PE' as Estado, 'Buenos Aires' as Municipio union all
	select 'PE' as Estado, 'Buíque' as Municipio union all
	select 'PE' as Estado, 'Cabo de Santo Agostinho' as Municipio union all
	select 'PE' as Estado, 'Cabrobó' as Municipio union all
	select 'PE' as Estado, 'Cachoeirinha' as Municipio union all
	select 'PE' as Estado, 'Caetés' as Municipio union all
	select 'PE' as Estado, 'Calçado' as Municipio union all
	select 'PE' as Estado, 'Calumbi' as Municipio union all
	select 'PE' as Estado, 'Camaragibe' as Municipio union all
	select 'PE' as Estado, 'Camocim de São Félix' as Municipio union all
	select 'PE' as Estado, 'Camutanga' as Municipio union all
	select 'PE' as Estado, 'Canhotinho' as Municipio union all
	select 'PE' as Estado, 'Capoeiras' as Municipio union all
	select 'PE' as Estado, 'Carnaíba' as Municipio union all
	select 'PE' as Estado, 'Carnaubeira da Penha' as Municipio union all
	select 'PE' as Estado, 'Carpina' as Municipio union all
	select 'PE' as Estado, 'Caruaru' as Municipio union all
	select 'PE' as Estado, 'Casinhas' as Municipio union all
	select 'PE' as Estado, 'Catende' as Municipio union all
	select 'PE' as Estado, 'Cedro' as Municipio union all
	select 'PE' as Estado, 'Chã de Alegria' as Municipio union all
	select 'PE' as Estado, 'Chã Grande' as Municipio union all
	select 'PE' as Estado, 'Condado' as Municipio union all
	select 'PE' as Estado, 'Correntes' as Municipio union all
	select 'PE' as Estado, 'Cortês' as Municipio union all
	select 'PE' as Estado, 'Cumaru' as Municipio union all
	select 'PE' as Estado, 'Cupira' as Municipio union all
	select 'PE' as Estado, 'Custódia' as Municipio union all
	select 'PE' as Estado, 'Dormentes' as Municipio union all
	select 'PE' as Estado, 'Escada' as Municipio union all
	select 'PE' as Estado, 'Exu' as Municipio union all
	select 'PE' as Estado, 'Feira Nova' as Municipio union all
	select 'PE' as Estado, 'Fernando de Noronha' as Municipio union all
	select 'PE' as Estado, 'Ferreiros' as Municipio union all
	select 'PE' as Estado, 'Flores' as Municipio union all
	select 'PE' as Estado, 'Floresta' as Municipio union all
	select 'PE' as Estado, 'Frei Miguelinho' as Municipio union all
	select 'PE' as Estado, 'Gameleira' as Municipio union all
	select 'PE' as Estado, 'Garanhuns' as Municipio union all
	select 'PE' as Estado, 'Glória do Goitá' as Municipio union all
	select 'PE' as Estado, 'Goiana' as Municipio union all
	select 'PE' as Estado, 'Granito' as Municipio union all
	select 'PE' as Estado, 'Gravatá' as Municipio union all
	select 'PE' as Estado, 'Iati' as Municipio union all
	select 'PE' as Estado, 'Ibimirim' as Municipio union all
	select 'PE' as Estado, 'Ibirajuba' as Municipio union all
	select 'PE' as Estado, 'Igarassu' as Municipio union all
	select 'PE' as Estado, 'Iguaraci' as Municipio union all
	select 'PE' as Estado, 'Ilha de Itamaracá' as Municipio union all
	select 'PE' as Estado, 'Inajá' as Municipio union all
	select 'PE' as Estado, 'Ingazeira' as Municipio union all
	select 'PE' as Estado, 'Ipojuca' as Municipio union all
	select 'PE' as Estado, 'Ipubi' as Municipio union all
	select 'PE' as Estado, 'Itacuruba' as Municipio union all
	select 'PE' as Estado, 'Itaíba' as Municipio union all
	select 'PE' as Estado, 'Itambé' as Municipio union all
	select 'PE' as Estado, 'Itapetim' as Municipio union all
	select 'PE' as Estado, 'Itapissuma' as Municipio union all
	select 'PE' as Estado, 'Itaquitinga' as Municipio union all
	select 'PE' as Estado, 'Jaboatão dos Guararapes' as Municipio union all
	select 'PE' as Estado, 'Jaqueira' as Municipio union all
	select 'PE' as Estado, 'Jataúba' as Municipio union all
	select 'PE' as Estado, 'Jatobá' as Municipio union all
	select 'PE' as Estado, 'João Alfredo' as Municipio union all
	select 'PE' as Estado, 'Joaquim Nabuco' as Municipio union all
	select 'PE' as Estado, 'Jucati' as Municipio union all
	select 'PE' as Estado, 'Jupi' as Municipio union all
	select 'PE' as Estado, 'Jurema' as Municipio union all
	select 'PE' as Estado, 'Lagoa do Carro' as Municipio union all
	select 'PE' as Estado, 'Lagoa do Itaenga' as Municipio union all
	select 'PE' as Estado, 'Lagoa do Ouro' as Municipio union all
	select 'PE' as Estado, 'Lagoa dos Gatos' as Municipio union all
	select 'PE' as Estado, 'Lagoa Grande' as Municipio union all
	select 'PE' as Estado, 'Lajedo' as Municipio union all
	select 'PE' as Estado, 'Limoeiro' as Municipio union all
	select 'PE' as Estado, 'Macaparana' as Municipio union all
	select 'PE' as Estado, 'Machados' as Municipio union all
	select 'PE' as Estado, 'Manari' as Municipio union all
	select 'PE' as Estado, 'Maraial' as Municipio union all
	select 'PE' as Estado, 'Mirandiba' as Municipio union all
	select 'PE' as Estado, 'Moreilândia' as Municipio union all
	select 'PE' as Estado, 'Moreno' as Municipio union all
	select 'PE' as Estado, 'Nazaré da Mata' as Municipio union all
	select 'PE' as Estado, 'Olinda' as Municipio union all
	select 'PE' as Estado, 'Orobó' as Municipio union all
	select 'PE' as Estado, 'Orocó' as Municipio union all
	select 'PE' as Estado, 'Ouricuri' as Municipio union all
	select 'PE' as Estado, 'Palmares' as Municipio union all
	select 'PE' as Estado, 'Palmeirina' as Municipio union all
	select 'PE' as Estado, 'Panelas' as Municipio union all
	select 'PE' as Estado, 'Paranatama' as Municipio union all
	select 'PE' as Estado, 'Parnamirim' as Municipio union all
	select 'PE' as Estado, 'Passira' as Municipio union all
	select 'PE' as Estado, 'Paudalho' as Municipio union all
	select 'PE' as Estado, 'Paulista' as Municipio union all
	select 'PE' as Estado, 'Pedra' as Municipio union all
	select 'PE' as Estado, 'Pesqueira' as Municipio union all
	select 'PE' as Estado, 'Petrolândia' as Municipio union all
	select 'PE' as Estado, 'Petrolina' as Municipio union all
	select 'PE' as Estado, 'Poção' as Municipio union all
	select 'PE' as Estado, 'Pombos' as Municipio union all
	select 'PE' as Estado, 'Primavera' as Municipio union all
	select 'PE' as Estado, 'Quipapá' as Municipio union all
	select 'PE' as Estado, 'Quixaba' as Municipio union all
	select 'PE' as Estado, 'Recife' as Municipio union all
	select 'PE' as Estado, 'Riacho das Almas' as Municipio union all
	select 'PE' as Estado, 'Ribeirão' as Municipio union all
	select 'PE' as Estado, 'Rio Formoso' as Municipio union all
	select 'PE' as Estado, 'Sairé' as Municipio union all
	select 'PE' as Estado, 'Salgadinho' as Municipio union all
	select 'PE' as Estado, 'Salgueiro' as Municipio union all
	select 'PE' as Estado, 'Saloá' as Municipio union all
	select 'PE' as Estado, 'Sanharó' as Municipio union all
	select 'PE' as Estado, 'Santa Cruz' as Municipio union all
	select 'PE' as Estado, 'Santa Cruz da Baixa Verde' as Municipio union all
	select 'PE' as Estado, 'Santa Cruz do Capibaribe' as Municipio union all
	select 'PE' as Estado, 'Santa Filomena' as Municipio union all
	select 'PE' as Estado, 'Santa Maria da Boa Vista' as Municipio union all
	select 'PE' as Estado, 'Santa Maria do Cambucá' as Municipio union all
	select 'PE' as Estado, 'Santa Terezinha' as Municipio union all
	select 'PE' as Estado, 'São Benedito do Sul' as Municipio union all
	select 'PE' as Estado, 'São Bento do Una' as Municipio union all
	select 'PE' as Estado, 'São Caitano' as Municipio union all
	select 'PE' as Estado, 'São João' as Municipio union all
	select 'PE' as Estado, 'São Joaquim do Monte' as Municipio union all
	select 'PE' as Estado, 'São José da Coroa Grande' as Municipio union all
	select 'PE' as Estado, 'São José do Belmonte' as Municipio union all
	select 'PE' as Estado, 'São José do Egito' as Municipio union all
	select 'PE' as Estado, 'São Lourenço da Mata' as Municipio union all
	select 'PE' as Estado, 'São Vicente Ferrer' as Municipio union all
	select 'PE' as Estado, 'Serra Talhada' as Municipio union all
	select 'PE' as Estado, 'Serrita' as Municipio union all
	select 'PE' as Estado, 'Sertânia' as Municipio union all
	select 'PE' as Estado, 'Sirinhaém' as Municipio union all
	select 'PE' as Estado, 'Solidão' as Municipio union all
	select 'PE' as Estado, 'Surubim' as Municipio union all
	select 'PE' as Estado, 'Tabira' as Municipio union all
	select 'PE' as Estado, 'Tacaimbó' as Municipio union all
	select 'PE' as Estado, 'Tacaratu' as Municipio union all
	select 'PE' as Estado, 'Tamandaré' as Municipio union all
	select 'PE' as Estado, 'Taquaritinga do Norte' as Municipio union all
	select 'PE' as Estado, 'Terezinha' as Municipio union all
	select 'PE' as Estado, 'Terra Nova' as Municipio union all
	select 'PE' as Estado, 'Timbaúba' as Municipio union all
	select 'PE' as Estado, 'Toritama' as Municipio union all
	select 'PE' as Estado, 'Tracunhaém' as Municipio union all
	select 'PE' as Estado, 'Trindade' as Municipio union all
	select 'PE' as Estado, 'Triunfo' as Municipio union all
	select 'PE' as Estado, 'Tupanatinga' as Municipio union all
	select 'PE' as Estado, 'Tuparetama' as Municipio union all
	select 'PE' as Estado, 'Venturosa' as Municipio union all
	select 'PE' as Estado, 'Verdejante' as Municipio union all
	select 'PE' as Estado, 'Vertente do Lério' as Municipio union all
	select 'PE' as Estado, 'Vertentes' as Municipio union all
	select 'PE' as Estado, 'Vicência' as Municipio union all
	select 'PE' as Estado, 'Vitória de Santo Antão' as Municipio union all
	select 'PE' as Estado, 'Xexéu' as Municipio union all
	select 'AL' as Estado, 'Água Branca' as Municipio union all
	select 'AL' as Estado, 'Anadia' as Municipio union all
	select 'AL' as Estado, 'Arapiraca' as Municipio union all
	select 'AL' as Estado, 'Atalaia' as Municipio union all
	select 'AL' as Estado, 'Barra de Santo Antônio' as Municipio union all
	select 'AL' as Estado, 'Barra de São Miguel' as Municipio union all
	select 'AL' as Estado, 'Batalha' as Municipio union all
	select 'AL' as Estado, 'Belém' as Municipio union all
	select 'AL' as Estado, 'Belo Monte' as Municipio union all
	select 'AL' as Estado, 'Boca da Mata' as Municipio union all
	select 'AL' as Estado, 'Branquinha' as Municipio union all
	select 'AL' as Estado, 'Cacimbinhas' as Municipio union all
	select 'AL' as Estado, 'Cajueiro' as Municipio union all
	select 'AL' as Estado, 'Campestre' as Municipio union all
	select 'AL' as Estado, 'Campo Alegre' as Municipio union all
	select 'AL' as Estado, 'Campo Grande' as Municipio union all
	select 'AL' as Estado, 'Canapi' as Municipio union all
	select 'AL' as Estado, 'Capela' as Municipio union all
	select 'AL' as Estado, 'Carneiros' as Municipio union all
	select 'AL' as Estado, 'Chã Preta' as Municipio union all
	select 'AL' as Estado, 'Coité do Nóia' as Municipio union all
	select 'AL' as Estado, 'Colônia Leopoldina' as Municipio union all
	select 'AL' as Estado, 'Coqueiro Seco' as Municipio union all
	select 'AL' as Estado, 'Coruripe' as Municipio union all
	select 'AL' as Estado, 'Craíbas' as Municipio union all
	select 'AL' as Estado, 'Delmiro Gouveia' as Municipio union all
	select 'AL' as Estado, 'Dois Riachos' as Municipio union all
	select 'AL' as Estado, 'Estrela de Alagoas' as Municipio union all
	select 'AL' as Estado, 'Feira Grande' as Municipio union all
	select 'AL' as Estado, 'Feliz Deserto' as Municipio union all
	select 'AL' as Estado, 'Flexeiras' as Municipio union all
	select 'AL' as Estado, 'Girau do Ponciano' as Municipio union all
	select 'AL' as Estado, 'Ibateguara' as Municipio union all
	select 'AL' as Estado, 'Igaci' as Municipio union all
	select 'AL' as Estado, 'Igreja Nova' as Municipio union all
	select 'AL' as Estado, 'Inhapi' as Municipio union all
	select 'AL' as Estado, 'Jacaré dos Homens' as Municipio union all
	select 'AL' as Estado, 'Jacuípe' as Municipio union all
	select 'AL' as Estado, 'Japaratinga' as Municipio union all
	select 'AL' as Estado, 'Jaramataia' as Municipio union all
	select 'AL' as Estado, 'Jequiá da Praia' as Municipio union all
	select 'AL' as Estado, 'Joaquim Gomes' as Municipio union all
	select 'AL' as Estado, 'Jundiá' as Municipio union all
	select 'AL' as Estado, 'Junqueiro' as Municipio union all
	select 'AL' as Estado, 'Lagoa da Canoa' as Municipio union all
	select 'AL' as Estado, 'Limoeiro de Anadia' as Municipio union all
	select 'AL' as Estado, 'Maceió' as Municipio union all
	select 'AL' as Estado, 'Major Isidoro' as Municipio union all
	select 'AL' as Estado, 'Mar Vermelho' as Municipio union all
	select 'AL' as Estado, 'Maragogi' as Municipio union all
	select 'AL' as Estado, 'Maravilha' as Municipio union all
	select 'AL' as Estado, 'Marechal Deodoro' as Municipio union all
	select 'AL' as Estado, 'Maribondo' as Municipio union all
	select 'AL' as Estado, 'Mata Grande' as Municipio union all
	select 'AL' as Estado, 'Matriz de Camaragibe' as Municipio union all
	select 'AL' as Estado, 'Messias' as Municipio union all
	select 'AL' as Estado, 'Minador do Negrão' as Municipio union all
	select 'AL' as Estado, 'Monteirópolis' as Municipio union all
	select 'AL' as Estado, 'Murici' as Municipio union all
	select 'AL' as Estado, 'Novo Lino' as Municipio union all
	select 'AL' as Estado, 'Olho d''Água das Flores' as Municipio union all
	select 'AL' as Estado, 'Olho d''Água do Casado' as Municipio union all
	select 'AL' as Estado, 'Olho d''Água Grande' as Municipio union all
	select 'AL' as Estado, 'Olivença' as Municipio union all
	select 'AL' as Estado, 'Ouro Branco' as Municipio union all
	select 'AL' as Estado, 'Palestina' as Municipio union all
	select 'AL' as Estado, 'Palmeira dos Índios' as Municipio union all
	select 'AL' as Estado, 'Pão de Açúcar' as Municipio union all
	select 'AL' as Estado, 'Pariconha' as Municipio union all
	select 'AL' as Estado, 'Paripueira' as Municipio union all
	select 'AL' as Estado, 'Passo de Camaragibe' as Municipio union all
	select 'AL' as Estado, 'Paulo Jacinto' as Municipio union all
	select 'AL' as Estado, 'Penedo' as Municipio union all
	select 'AL' as Estado, 'Piaçabuçu' as Municipio union all
	select 'AL' as Estado, 'Pilar' as Municipio union all
	select 'AL' as Estado, 'Pindoba' as Municipio union all
	select 'AL' as Estado, 'Piranhas' as Municipio union all
	select 'AL' as Estado, 'Poço das Trincheiras' as Municipio union all
	select 'AL' as Estado, 'Porto Calvo' as Municipio union all
	select 'AL' as Estado, 'Porto de Pedras' as Municipio union all
	select 'AL' as Estado, 'Porto Real do Colégio' as Municipio union all
	select 'AL' as Estado, 'Quebrangulo' as Municipio union all
	select 'AL' as Estado, 'Rio Largo' as Municipio union all
	select 'AL' as Estado, 'Roteiro' as Municipio union all
	select 'AL' as Estado, 'Santa Luzia do Norte' as Municipio union all
	select 'AL' as Estado, 'Santana do Ipanema' as Municipio union all
	select 'AL' as Estado, 'Santana do Mundaú' as Municipio union all
	select 'AL' as Estado, 'São Brás' as Municipio union all
	select 'AL' as Estado, 'São José da Laje' as Municipio union all
	select 'AL' as Estado, 'São José da Tapera' as Municipio union all
	select 'AL' as Estado, 'São Luís do Quitunde' as Municipio union all
	select 'AL' as Estado, 'São Miguel dos Campos' as Municipio union all
	select 'AL' as Estado, 'São Miguel dos Milagres' as Municipio union all
	select 'AL' as Estado, 'São Sebastião' as Municipio union all
	select 'AL' as Estado, 'Satuba' as Municipio union all
	select 'AL' as Estado, 'Senador Rui Palmeira' as Municipio union all
	select 'AL' as Estado, 'Tanque d''Arca' as Municipio union all
	select 'AL' as Estado, 'Taquarana' as Municipio union all
	select 'AL' as Estado, 'Teotônio Vilela' as Municipio union all
	select 'AL' as Estado, 'Traipu' as Municipio union all
	select 'AL' as Estado, 'União dos Palmares' as Municipio union all
	select 'AL' as Estado, 'Viçosa' as Municipio union all
	select 'SE' as Estado, 'Amparo de São Francisco' as Municipio union all
	select 'SE' as Estado, 'Aquidabã' as Municipio union all
	select 'SE' as Estado, 'Aracaju' as Municipio union all
	select 'SE' as Estado, 'Arauá' as Municipio union all
	select 'SE' as Estado, 'Areia Branca' as Municipio union all
	select 'SE' as Estado, 'Barra dos Coqueiros' as Municipio union all
	select 'SE' as Estado, 'Boquim' as Municipio union all
	select 'SE' as Estado, 'Brejo Grande' as Municipio union all
	select 'SE' as Estado, 'Campo do Brito' as Municipio union all
	select 'SE' as Estado, 'Canhoba' as Municipio union all
	select 'SE' as Estado, 'Canindé de São Francisco' as Municipio union all
	select 'SE' as Estado, 'Capela' as Municipio union all
	select 'SE' as Estado, 'Carira' as Municipio union all
	select 'SE' as Estado, 'Carmópolis' as Municipio union all
	select 'SE' as Estado, 'Cedro de São João' as Municipio union all
	select 'SE' as Estado, 'Cristinápolis' as Municipio union all
	select 'SE' as Estado, 'Cumbe' as Municipio union all
	select 'SE' as Estado, 'Divina Pastora' as Municipio union all
	select 'SE' as Estado, 'Estância' as Municipio union all
	select 'SE' as Estado, 'Feira Nova' as Municipio union all
	select 'SE' as Estado, 'Frei Paulo' as Municipio union all
	select 'SE' as Estado, 'Gararu' as Municipio union all
	select 'SE' as Estado, 'General Maynard' as Municipio union all
	select 'SE' as Estado, 'Gracho Cardoso' as Municipio union all
	select 'SE' as Estado, 'Ilha das Flores' as Municipio union all
	select 'SE' as Estado, 'Indiaroba' as Municipio union all
	select 'SE' as Estado, 'Itabaiana' as Municipio union all
	select 'SE' as Estado, 'Itabaianinha' as Municipio union all
	select 'SE' as Estado, 'Itabi' as Municipio union all
	select 'SE' as Estado, 'Itaporanga d''Ajuda' as Municipio union all
	select 'SE' as Estado, 'Japaratuba' as Municipio union all
	select 'SE' as Estado, 'Japoatã' as Municipio union all
	select 'SE' as Estado, 'Lagarto' as Municipio union all
	select 'SE' as Estado, 'Laranjeiras' as Municipio union all
	select 'SE' as Estado, 'Macambira' as Municipio union all
	select 'SE' as Estado, 'Malhada dos Bois' as Municipio union all
	select 'SE' as Estado, 'Malhador' as Municipio union all
	select 'SE' as Estado, 'Maruim' as Municipio union all
	select 'SE' as Estado, 'Moita Bonita' as Municipio union all
	select 'SE' as Estado, 'Monte Alegre de Sergipe' as Municipio union all
	select 'SE' as Estado, 'Muribeca' as Municipio union all
	select 'SE' as Estado, 'Neópolis' as Municipio union all
	select 'SE' as Estado, 'Nossa Senhora Aparecida' as Municipio union all
	select 'SE' as Estado, 'Nossa Senhora da Glória' as Municipio union all
	select 'SE' as Estado, 'Nossa Senhora das Dores' as Municipio union all
	select 'SE' as Estado, 'Nossa Senhora de Lourdes' as Municipio union all
	select 'SE' as Estado, 'Nossa Senhora do Socorro' as Municipio union all
	select 'SE' as Estado, 'Pacatuba' as Municipio union all
	select 'SE' as Estado, 'Pedra Mole' as Municipio union all
	select 'SE' as Estado, 'Pedrinhas' as Municipio union all
	select 'SE' as Estado, 'Pinhão' as Municipio union all
	select 'SE' as Estado, 'Pirambu' as Municipio union all
	select 'SE' as Estado, 'Poço Redondo' as Municipio union all
	select 'SE' as Estado, 'Poço Verde' as Municipio union all
	select 'SE' as Estado, 'Porto da Folha' as Municipio union all
	select 'SE' as Estado, 'Propriá' as Municipio union all
	select 'SE' as Estado, 'Riachão do Dantas' as Municipio union all
	select 'SE' as Estado, 'Riachuelo' as Municipio union all
	select 'SE' as Estado, 'Ribeirópolis' as Municipio union all
	select 'SE' as Estado, 'Rosário do Catete' as Municipio union all
	select 'SE' as Estado, 'Salgado' as Municipio union all
	select 'SE' as Estado, 'Santa Luzia do Itanhy' as Municipio union all
	select 'SE' as Estado, 'Santa Rosa de Lima' as Municipio union all
	select 'SE' as Estado, 'Santana do São Francisco' as Municipio union all
	select 'SE' as Estado, 'Santo Amaro das Brotas' as Municipio union all
	select 'SE' as Estado, 'São Cristóvão' as Municipio union all
	select 'SE' as Estado, 'São Domingos' as Municipio union all
	select 'SE' as Estado, 'São Francisco' as Municipio union all
	select 'SE' as Estado, 'São Miguel do Aleixo' as Municipio union all
	select 'SE' as Estado, 'Simão Dias' as Municipio union all
	select 'SE' as Estado, 'Siriri' as Municipio union all
	select 'SE' as Estado, 'Telha' as Municipio union all
	select 'SE' as Estado, 'Tobias Barreto' as Municipio union all
	select 'SE' as Estado, 'Tomar do Geru' as Municipio union all
	select 'SE' as Estado, 'Umbaúba' as Municipio union all
	select 'BA' as Estado, 'Abaíra' as Municipio union all
	select 'BA' as Estado, 'Abaré' as Municipio union all
	select 'BA' as Estado, 'Acajutiba' as Municipio union all
	select 'BA' as Estado, 'Adustina' as Municipio union all
	select 'BA' as Estado, 'Água Fria' as Municipio union all
	select 'BA' as Estado, 'Aiquara' as Municipio union all
	select 'BA' as Estado, 'Alagoinhas' as Municipio union all
	select 'BA' as Estado, 'Alcobaça' as Municipio union all
	select 'BA' as Estado, 'Almadina' as Municipio union all
	select 'BA' as Estado, 'Amargosa' as Municipio union all
	select 'BA' as Estado, 'Amélia Rodrigues' as Municipio union all
	select 'BA' as Estado, 'América Dourada' as Municipio union all
	select 'BA' as Estado, 'Anagé' as Municipio union all
	select 'BA' as Estado, 'Andaraí' as Municipio union all
	select 'BA' as Estado, 'Andorinha' as Municipio union all
	select 'BA' as Estado, 'Angical' as Municipio union all
	select 'BA' as Estado, 'Anguera' as Municipio union all
	select 'BA' as Estado, 'Antas' as Municipio union all
	select 'BA' as Estado, 'Antônio Cardoso' as Municipio union all
	select 'BA' as Estado, 'Antônio Gonçalves' as Municipio union all
	select 'BA' as Estado, 'Aporá' as Municipio union all
	select 'BA' as Estado, 'Apuarema' as Municipio union all
	select 'BA' as Estado, 'Araças' as Municipio union all
	select 'BA' as Estado, 'Aracatu' as Municipio union all
	select 'BA' as Estado, 'Araci' as Municipio union all
	select 'BA' as Estado, 'Aramari' as Municipio union all
	select 'BA' as Estado, 'Arataca' as Municipio union all
	select 'BA' as Estado, 'Aratuípe' as Municipio union all
	select 'BA' as Estado, 'Aurelino Leal' as Municipio union all
	select 'BA' as Estado, 'Baianópolis' as Municipio union all
	select 'BA' as Estado, 'Baixa Grande' as Municipio union all
	select 'BA' as Estado, 'Banzaê' as Municipio union all
	select 'BA' as Estado, 'Barra' as Municipio union all
	select 'BA' as Estado, 'Barra da Estiva' as Municipio union all
	select 'BA' as Estado, 'Barra do Choça' as Municipio union all
	select 'BA' as Estado, 'Barra do Mendes' as Municipio union all
	select 'BA' as Estado, 'Barra do Rocha' as Municipio union all
	select 'BA' as Estado, 'Barreiras' as Municipio union all
	select 'BA' as Estado, 'Barro Alto' as Municipio union all
	select 'BA' as Estado, 'Barro Preto' as Municipio union all
	select 'BA' as Estado, 'Barrocas' as Municipio union all
	select 'BA' as Estado, 'Belmonte' as Municipio union all
	select 'BA' as Estado, 'Belo Campo' as Municipio union all
	select 'BA' as Estado, 'Biritinga' as Municipio union all
	select 'BA' as Estado, 'Boa Nova' as Municipio union all
	select 'BA' as Estado, 'Boa Vista do Tupim' as Municipio union all
	select 'BA' as Estado, 'Bom Jesus da Lapa' as Municipio union all
	select 'BA' as Estado, 'Bom Jesus da Serra' as Municipio union all
	select 'BA' as Estado, 'Boninal' as Municipio union all
	select 'BA' as Estado, 'Bonito' as Municipio union all
	select 'BA' as Estado, 'Boquira' as Municipio union all
	select 'BA' as Estado, 'Botuporã' as Municipio union all
	select 'BA' as Estado, 'Brejões' as Municipio union all
	select 'BA' as Estado, 'Brejolândia' as Municipio union all
	select 'BA' as Estado, 'Brotas de Macaúbas' as Municipio union all
	select 'BA' as Estado, 'Brumado' as Municipio union all
	select 'BA' as Estado, 'Buerarema' as Municipio union all
	select 'BA' as Estado, 'Buritirama' as Municipio union all
	select 'BA' as Estado, 'Caatiba' as Municipio union all
	select 'BA' as Estado, 'Cabaceiras do Paraguaçu' as Municipio union all
	select 'BA' as Estado, 'Cachoeira' as Municipio union all
	select 'BA' as Estado, 'Caculé' as Municipio union all
	select 'BA' as Estado, 'Caém' as Municipio union all
	select 'BA' as Estado, 'Caetanos' as Municipio union all
	select 'BA' as Estado, 'Caetité' as Municipio union all
	select 'BA' as Estado, 'Cafarnaum' as Municipio union all
	select 'BA' as Estado, 'Cairu' as Municipio union all
	select 'BA' as Estado, 'Caldeirão Grande' as Municipio union all
	select 'BA' as Estado, 'Camacan' as Municipio union all
	select 'BA' as Estado, 'Camaçari' as Municipio union all
	select 'BA' as Estado, 'Camamu' as Municipio union all
	select 'BA' as Estado, 'Campo Alegre de Lourdes' as Municipio union all
	select 'BA' as Estado, 'Campo Formoso' as Municipio union all
	select 'BA' as Estado, 'Canápolis' as Municipio union all
	select 'BA' as Estado, 'Canarana' as Municipio union all
	select 'BA' as Estado, 'Canavieiras' as Municipio union all
	select 'BA' as Estado, 'Candeal' as Municipio union all
	select 'BA' as Estado, 'Candeias' as Municipio union all
	select 'BA' as Estado, 'Candiba' as Municipio union all
	select 'BA' as Estado, 'Cândido Sales' as Municipio union all
	select 'BA' as Estado, 'Cansanção' as Municipio union all
	select 'BA' as Estado, 'Canudos' as Municipio union all
	select 'BA' as Estado, 'Capela do Alto Alegre' as Municipio union all
	select 'BA' as Estado, 'Capim Grosso' as Municipio union all
	select 'BA' as Estado, 'Caraíbas' as Municipio union all
	select 'BA' as Estado, 'Caravelas' as Municipio union all
	select 'BA' as Estado, 'Cardeal da Silva' as Municipio union all
	select 'BA' as Estado, 'Carinhanha' as Municipio union all
	select 'BA' as Estado, 'Casa Nova' as Municipio union all
	select 'BA' as Estado, 'Castro Alves' as Municipio union all
	select 'BA' as Estado, 'Catolândia' as Municipio union all
	select 'BA' as Estado, 'Catu' as Municipio union all
	select 'BA' as Estado, 'Caturama' as Municipio union all
	select 'BA' as Estado, 'Central' as Municipio union all
	select 'BA' as Estado, 'Chorrochó' as Municipio union all
	select 'BA' as Estado, 'Cícero Dantas' as Municipio union all
	select 'BA' as Estado, 'Cipó' as Municipio union all
	select 'BA' as Estado, 'Coaraci' as Municipio union all
	select 'BA' as Estado, 'Cocos' as Municipio union all
	select 'BA' as Estado, 'Conceição da Feira' as Municipio union all
	select 'BA' as Estado, 'Conceição do Almeida' as Municipio union all
	select 'BA' as Estado, 'Conceição do Coité' as Municipio union all
	select 'BA' as Estado, 'Conceição do Jacuípe' as Municipio union all
	select 'BA' as Estado, 'Conde' as Municipio union all
	select 'BA' as Estado, 'Condeúba' as Municipio union all
	select 'BA' as Estado, 'Contendas do Sincorá' as Municipio union all
	select 'BA' as Estado, 'Coração de Maria' as Municipio union all
	select 'BA' as Estado, 'Cordeiros' as Municipio union all
	select 'BA' as Estado, 'Coribe' as Municipio union all
	select 'BA' as Estado, 'Coronel João Sá' as Municipio union all
	select 'BA' as Estado, 'Correntina' as Municipio union all
	select 'BA' as Estado, 'Cotegipe' as Municipio union all
	select 'BA' as Estado, 'Cravolândia' as Municipio union all
	select 'BA' as Estado, 'Crisópolis' as Municipio union all
	select 'BA' as Estado, 'Cristópolis' as Municipio union all
	select 'BA' as Estado, 'Cruz das Almas' as Municipio union all
	select 'BA' as Estado, 'Curaçá' as Municipio union all
	select 'BA' as Estado, 'Dário Meira' as Municipio union all
	select 'BA' as Estado, 'Dias d''Ávila' as Municipio union all
	select 'BA' as Estado, 'Dom Basílio' as Municipio union all
	select 'BA' as Estado, 'Dom Macedo Costa' as Municipio union all
	select 'BA' as Estado, 'Elísio Medrado' as Municipio union all
	select 'BA' as Estado, 'Encruzilhada' as Municipio union all
	select 'BA' as Estado, 'Entre Rios' as Municipio union all
	select 'BA' as Estado, 'Érico Cardoso' as Municipio union all
	select 'BA' as Estado, 'Esplanada' as Municipio union all
	select 'BA' as Estado, 'Euclides da Cunha' as Municipio union all
	select 'BA' as Estado, 'Eunápolis' as Municipio union all
	select 'BA' as Estado, 'Fátima' as Municipio union all
	select 'BA' as Estado, 'Feira da Mata' as Municipio union all
	select 'BA' as Estado, 'Feira de Santana' as Municipio union all
	select 'BA' as Estado, 'Filadélfia' as Municipio union all
	select 'BA' as Estado, 'Firmino Alves' as Municipio union all
	select 'BA' as Estado, 'Floresta Azul' as Municipio union all
	select 'BA' as Estado, 'Formosa do Rio Preto' as Municipio union all
	select 'BA' as Estado, 'Gandu' as Municipio union all
	select 'BA' as Estado, 'Gavião' as Municipio union all
	select 'BA' as Estado, 'Gentio do Ouro' as Municipio union all
	select 'BA' as Estado, 'Glória' as Municipio union all
	select 'BA' as Estado, 'Gongogi' as Municipio union all
	select 'BA' as Estado, 'Governador Mangabeira' as Municipio union all
	select 'BA' as Estado, 'Guajeru' as Municipio union all
	select 'BA' as Estado, 'Guanambi' as Municipio union all
	select 'BA' as Estado, 'Guaratinga' as Municipio union all
	select 'BA' as Estado, 'Heliópolis' as Municipio union all
	select 'BA' as Estado, 'Iaçu' as Municipio union all
	select 'BA' as Estado, 'Ibiassucê' as Municipio union all
	select 'BA' as Estado, 'Ibicaraí' as Municipio union all
	select 'BA' as Estado, 'Ibicoara' as Municipio union all
	select 'BA' as Estado, 'Ibicuí' as Municipio union all
	select 'BA' as Estado, 'Ibipeba' as Municipio union all
	select 'BA' as Estado, 'Ibipitanga' as Municipio union all
	select 'BA' as Estado, 'Ibiquera' as Municipio union all
	select 'BA' as Estado, 'Ibirapitanga' as Municipio union all
	select 'BA' as Estado, 'Ibirapuã' as Municipio union all
	select 'BA' as Estado, 'Ibirataia' as Municipio union all
	select 'BA' as Estado, 'Ibitiara' as Municipio union all
	select 'BA' as Estado, 'Ibititá' as Municipio union all
	select 'BA' as Estado, 'Ibotirama' as Municipio union all
	select 'BA' as Estado, 'Ichu' as Municipio union all
	select 'BA' as Estado, 'Igaporã' as Municipio union all
	select 'BA' as Estado, 'Igrapiúna' as Municipio union all
	select 'BA' as Estado, 'Iguaí' as Municipio union all
	select 'BA' as Estado, 'Ilhéus' as Municipio union all
	select 'BA' as Estado, 'Inhambupe' as Municipio union all
	select 'BA' as Estado, 'Ipecaetá' as Municipio union all
	select 'BA' as Estado, 'Ipiaú' as Municipio union all
	select 'BA' as Estado, 'Ipirá' as Municipio union all
	select 'BA' as Estado, 'Ipupiara' as Municipio union all
	select 'BA' as Estado, 'Irajuba' as Municipio union all
	select 'BA' as Estado, 'Iramaia' as Municipio union all
	select 'BA' as Estado, 'Iraquara' as Municipio union all
	select 'BA' as Estado, 'Irará' as Municipio union all
	select 'BA' as Estado, 'Irecê' as Municipio union all
	select 'BA' as Estado, 'Itabela' as Municipio union all
	select 'BA' as Estado, 'Itaberaba' as Municipio union all
	select 'BA' as Estado, 'Itabuna' as Municipio union all
	select 'BA' as Estado, 'Itacaré' as Municipio union all
	select 'BA' as Estado, 'Itaeté' as Municipio union all
	select 'BA' as Estado, 'Itagi' as Municipio union all
	select 'BA' as Estado, 'Itagibá' as Municipio union all
	select 'BA' as Estado, 'Itagimirim' as Municipio union all
	select 'BA' as Estado, 'Itaguaçu da Bahia' as Municipio union all
	select 'BA' as Estado, 'Itaju do Colônia' as Municipio union all
	select 'BA' as Estado, 'Itajuípe' as Municipio union all
	select 'BA' as Estado, 'Itamaraju' as Municipio union all
	select 'BA' as Estado, 'Itamari' as Municipio union all
	select 'BA' as Estado, 'Itambé' as Municipio union all
	select 'BA' as Estado, 'Itanagra' as Municipio union all
	select 'BA' as Estado, 'Itanhém' as Municipio union all
	select 'BA' as Estado, 'Itaparica' as Municipio union all
	select 'BA' as Estado, 'Itapé' as Municipio union all
	select 'BA' as Estado, 'Itapebi' as Municipio union all
	select 'BA' as Estado, 'Itapetinga' as Municipio union all
	select 'BA' as Estado, 'Itapicuru' as Municipio union all
	select 'BA' as Estado, 'Itapitanga' as Municipio union all
	select 'BA' as Estado, 'Itaquara' as Municipio union all
	select 'BA' as Estado, 'Itarantim' as Municipio union all
	select 'BA' as Estado, 'Itatim' as Municipio union all
	select 'BA' as Estado, 'Itiruçu' as Municipio union all
	select 'BA' as Estado, 'Itiúba' as Municipio union all
	select 'BA' as Estado, 'Itororó' as Municipio union all
	select 'BA' as Estado, 'Ituaçu' as Municipio union all
	select 'BA' as Estado, 'Ituberá' as Municipio union all
	select 'BA' as Estado, 'Iuiú' as Municipio union all
	select 'BA' as Estado, 'Jaborandi' as Municipio union all
	select 'BA' as Estado, 'Jacaraci' as Municipio union all
	select 'BA' as Estado, 'Jacobina' as Municipio union all
	select 'BA' as Estado, 'Jaguaquara' as Municipio union all
	select 'BA' as Estado, 'Jaguarari' as Municipio union all
	select 'BA' as Estado, 'Jaguaripe' as Municipio union all
	select 'BA' as Estado, 'Jandaíra' as Municipio union all
	select 'BA' as Estado, 'Jequié' as Municipio union all
	select 'BA' as Estado, 'Jeremoabo' as Municipio union all
	select 'BA' as Estado, 'Jiquiriçá' as Municipio union all
	select 'BA' as Estado, 'Jitaúna' as Municipio union all
	select 'BA' as Estado, 'João Dourado' as Municipio union all
	select 'BA' as Estado, 'Juazeiro' as Municipio union all
	select 'BA' as Estado, 'Jucuruçu' as Municipio union all
	select 'BA' as Estado, 'Jussara' as Municipio union all
	select 'BA' as Estado, 'Jussari' as Municipio union all
	select 'BA' as Estado, 'Jussiape' as Municipio union all
	select 'BA' as Estado, 'Lafaiete Coutinho' as Municipio union all
	select 'BA' as Estado, 'Lagoa Real' as Municipio union all
	select 'BA' as Estado, 'Laje' as Municipio union all
	select 'BA' as Estado, 'Lajedão' as Municipio union all
	select 'BA' as Estado, 'Lajedinho' as Municipio union all
	select 'BA' as Estado, 'Lajedo do Tabocal' as Municipio union all
	select 'BA' as Estado, 'Lamarão' as Municipio union all
	select 'BA' as Estado, 'Lapão' as Municipio union all
	select 'BA' as Estado, 'Lauro de Freitas' as Municipio union all
	select 'BA' as Estado, 'Lençóis' as Municipio union all
	select 'BA' as Estado, 'Licínio de Almeida' as Municipio union all
	select 'BA' as Estado, 'Livramento de Nossa Senhora' as Municipio union all
	select 'BA' as Estado, 'Luís Eduardo Magalhães' as Municipio union all
	select 'BA' as Estado, 'Macajuba' as Municipio union all
	select 'BA' as Estado, 'Macarani' as Municipio union all
	select 'BA' as Estado, 'Macaúbas' as Municipio union all
	select 'BA' as Estado, 'Macururé' as Municipio union all
	select 'BA' as Estado, 'Madre de Deus' as Municipio union all
	select 'BA' as Estado, 'Maetinga' as Municipio union all
	select 'BA' as Estado, 'Maiquinique' as Municipio union all
	select 'BA' as Estado, 'Mairi' as Municipio union all
	select 'BA' as Estado, 'Malhada' as Municipio union all
	select 'BA' as Estado, 'Malhada de Pedras' as Municipio union all
	select 'BA' as Estado, 'Manoel Vitorino' as Municipio union all
	select 'BA' as Estado, 'Mansidão' as Municipio union all
	select 'BA' as Estado, 'Maracás' as Municipio union all
	select 'BA' as Estado, 'Maragogipe' as Municipio union all
	select 'BA' as Estado, 'Maraú' as Municipio union all
	select 'BA' as Estado, 'Marcionílio Souza' as Municipio union all
	select 'BA' as Estado, 'Mascote' as Municipio union all
	select 'BA' as Estado, 'Mata de São João' as Municipio union all
	select 'BA' as Estado, 'Matina' as Municipio union all
	select 'BA' as Estado, 'Medeiros Neto' as Municipio union all
	select 'BA' as Estado, 'Miguel Calmon' as Municipio union all
	select 'BA' as Estado, 'Milagres' as Municipio union all
	select 'BA' as Estado, 'Mirangaba' as Municipio union all
	select 'BA' as Estado, 'Mirante' as Municipio union all
	select 'BA' as Estado, 'Monte Santo' as Municipio union all
	select 'BA' as Estado, 'Morpará' as Municipio union all
	select 'BA' as Estado, 'Morro do Chapéu' as Municipio union all
	select 'BA' as Estado, 'Mortugaba' as Municipio union all
	select 'BA' as Estado, 'Mucugê' as Municipio union all
	select 'BA' as Estado, 'Mucuri' as Municipio union all
	select 'BA' as Estado, 'Mulungu do Morro' as Municipio union all
	select 'BA' as Estado, 'Mundo Novo' as Municipio union all
	select 'BA' as Estado, 'Muniz Ferreira' as Municipio union all
	select 'BA' as Estado, 'Muquém de São Francisco' as Municipio union all
	select 'BA' as Estado, 'Muritiba' as Municipio union all
	select 'BA' as Estado, 'Mutuípe' as Municipio union all
	select 'BA' as Estado, 'Nazaré' as Municipio union all
	select 'BA' as Estado, 'Nilo Peçanha' as Municipio union all
	select 'BA' as Estado, 'Nordestina' as Municipio union all
	select 'BA' as Estado, 'Nova Canaã' as Municipio union all
	select 'BA' as Estado, 'Nova Fátima' as Municipio union all
	select 'BA' as Estado, 'Nova Ibiá' as Municipio union all
	select 'BA' as Estado, 'Nova Itarana' as Municipio union all
	select 'BA' as Estado, 'Nova Redenção' as Municipio union all
	select 'BA' as Estado, 'Nova Soure' as Municipio union all
	select 'BA' as Estado, 'Nova Viçosa' as Municipio union all
	select 'BA' as Estado, 'Novo Horizonte' as Municipio union all
	select 'BA' as Estado, 'Novo Triunfo' as Municipio union all
	select 'BA' as Estado, 'Olindina' as Municipio union all
	select 'BA' as Estado, 'Oliveira dos Brejinhos' as Municipio union all
	select 'BA' as Estado, 'Ouriçangas' as Municipio union all
	select 'BA' as Estado, 'Ourolândia' as Municipio union all
	select 'BA' as Estado, 'Palmas de Monte Alto' as Municipio union all
	select 'BA' as Estado, 'Palmeiras' as Municipio union all
	select 'BA' as Estado, 'Paramirim' as Municipio union all
	select 'BA' as Estado, 'Paratinga' as Municipio union all
	select 'BA' as Estado, 'Paripiranga' as Municipio union all
	select 'BA' as Estado, 'Pau Brasil' as Municipio union all
	select 'BA' as Estado, 'Paulo Afonso' as Municipio union all
	select 'BA' as Estado, 'Pé de Serra' as Municipio union all
	select 'BA' as Estado, 'Pedrão' as Municipio union all
	select 'BA' as Estado, 'Pedro Alexandre' as Municipio union all
	select 'BA' as Estado, 'Piatã' as Municipio union all
	select 'BA' as Estado, 'Pilão Arcado' as Municipio union all
	select 'BA' as Estado, 'Pindaí' as Municipio union all
	select 'BA' as Estado, 'Pindobaçu' as Municipio union all
	select 'BA' as Estado, 'Pintadas' as Municipio union all
	select 'BA' as Estado, 'Piraí do Norte' as Municipio union all
	select 'BA' as Estado, 'Piripá' as Municipio union all
	select 'BA' as Estado, 'Piritiba' as Municipio union all
	select 'BA' as Estado, 'Planaltino' as Municipio union all
	select 'BA' as Estado, 'Planalto' as Municipio union all
	select 'BA' as Estado, 'Poções' as Municipio union all
	select 'BA' as Estado, 'Pojuca' as Municipio union all
	select 'BA' as Estado, 'Ponto Novo' as Municipio union all
	select 'BA' as Estado, 'Porto Seguro' as Municipio union all
	select 'BA' as Estado, 'Potiraguá' as Municipio union all
	select 'BA' as Estado, 'Prado' as Municipio union all
	select 'BA' as Estado, 'Presidente Dutra' as Municipio union all
	select 'BA' as Estado, 'Presidente Jânio Quadros' as Municipio union all
	select 'BA' as Estado, 'Presidente Tancredo Neves' as Municipio union all
	select 'BA' as Estado, 'Queimadas' as Municipio union all
	select 'BA' as Estado, 'Quijingue' as Municipio union all
	select 'BA' as Estado, 'Quixabeira' as Municipio union all
	select 'BA' as Estado, 'Rafael Jambeiro' as Municipio union all
	select 'BA' as Estado, 'Remanso' as Municipio union all
	select 'BA' as Estado, 'Retirolândia' as Municipio union all
	select 'BA' as Estado, 'Riachão das Neves' as Municipio union all
	select 'BA' as Estado, 'Riachão do Jacuípe' as Municipio union all
	select 'BA' as Estado, 'Riacho de Santana' as Municipio union all
	select 'BA' as Estado, 'Ribeira do Amparo' as Municipio union all
	select 'BA' as Estado, 'Ribeira do Pombal' as Municipio union all
	select 'BA' as Estado, 'Ribeirão do Largo' as Municipio union all
	select 'BA' as Estado, 'Rio de Contas' as Municipio union all
	select 'BA' as Estado, 'Rio do Antônio' as Municipio union all
	select 'BA' as Estado, 'Rio do Pires' as Municipio union all
	select 'BA' as Estado, 'Rio Real' as Municipio union all
	select 'BA' as Estado, 'Rodelas' as Municipio union all
	select 'BA' as Estado, 'Ruy Barbosa' as Municipio union all
	select 'BA' as Estado, 'Salinas da Margarida' as Municipio union all
	select 'BA' as Estado, 'Salvador' as Municipio union all
	select 'BA' as Estado, 'Santa Bárbara' as Municipio union all
	select 'BA' as Estado, 'Santa Brígida' as Municipio union all
	select 'BA' as Estado, 'Santa Cruz Cabrália' as Municipio union all
	select 'BA' as Estado, 'Santa Cruz da Vitória' as Municipio union all
	select 'BA' as Estado, 'Santa Inês' as Municipio union all
	select 'BA' as Estado, 'Santa Luzia' as Municipio union all
	select 'BA' as Estado, 'Santa Maria da Vitória' as Municipio union all
	select 'BA' as Estado, 'Santa Rita de Cássia' as Municipio union all
	select 'BA' as Estado, 'Santa Teresinha' as Municipio union all
	select 'BA' as Estado, 'Santaluz' as Municipio union all
	select 'BA' as Estado, 'Santana' as Municipio union all
	select 'BA' as Estado, 'Santanópolis' as Municipio union all
	select 'BA' as Estado, 'Santo Amaro' as Municipio union all
	select 'BA' as Estado, 'Santo Antônio de Jesus' as Municipio union all
	select 'BA' as Estado, 'Santo Estêvão' as Municipio union all
	select 'BA' as Estado, 'São Desidério' as Municipio union all
	select 'BA' as Estado, 'São Domingos' as Municipio union all
	select 'BA' as Estado, 'São Felipe' as Municipio union all
	select 'BA' as Estado, 'São Félix' as Municipio union all
	select 'BA' as Estado, 'São Félix do Coribe' as Municipio union all
	select 'BA' as Estado, 'São Francisco do Conde' as Municipio union all
	select 'BA' as Estado, 'São Gabriel' as Municipio union all
	select 'BA' as Estado, 'São Gonçalo dos Campos' as Municipio union all
	select 'BA' as Estado, 'São José da Vitória' as Municipio union all
	select 'BA' as Estado, 'São José do Jacuípe' as Municipio union all
	select 'BA' as Estado, 'São Miguel das Matas' as Municipio union all
	select 'BA' as Estado, 'São Sebastião do Passé' as Municipio union all
	select 'BA' as Estado, 'Sapeaçu' as Municipio union all
	select 'BA' as Estado, 'Sátiro Dias' as Municipio union all
	select 'BA' as Estado, 'Saubara' as Municipio union all
	select 'BA' as Estado, 'Saúde' as Municipio union all
	select 'BA' as Estado, 'Seabra' as Municipio union all
	select 'BA' as Estado, 'Sebastião Laranjeiras' as Municipio union all
	select 'BA' as Estado, 'Senhor do Bonfim' as Municipio union all
	select 'BA' as Estado, 'Sento Sé' as Municipio union all
	select 'BA' as Estado, 'Serra do Ramalho' as Municipio union all
	select 'BA' as Estado, 'Serra Dourada' as Municipio union all
	select 'BA' as Estado, 'Serra Preta' as Municipio union all
	select 'BA' as Estado, 'Serrinha' as Municipio union all
	select 'BA' as Estado, 'Serrolândia' as Municipio union all
	select 'BA' as Estado, 'Simões Filho' as Municipio union all
	select 'BA' as Estado, 'Sítio do Mato' as Municipio union all
	select 'BA' as Estado, 'Sítio do Quinto' as Municipio union all
	select 'BA' as Estado, 'Sobradinho' as Municipio union all
	select 'BA' as Estado, 'Souto Soares' as Municipio union all
	select 'BA' as Estado, 'Tabocas do Brejo Velho' as Municipio union all
	select 'BA' as Estado, 'Tanhaçu' as Municipio union all
	select 'BA' as Estado, 'Tanque Novo' as Municipio union all
	select 'BA' as Estado, 'Tanquinho' as Municipio union all
	select 'BA' as Estado, 'Taperoá' as Municipio union all
	select 'BA' as Estado, 'Tapiramutá' as Municipio union all
	select 'BA' as Estado, 'Teixeira de Freitas' as Municipio union all
	select 'BA' as Estado, 'Teodoro Sampaio' as Municipio union all
	select 'BA' as Estado, 'Teofilândia' as Municipio union all
	select 'BA' as Estado, 'Teolândia' as Municipio union all
	select 'BA' as Estado, 'Terra Nova' as Municipio union all
	select 'BA' as Estado, 'Tremedal' as Municipio union all
	select 'BA' as Estado, 'Tucano' as Municipio union all
	select 'BA' as Estado, 'Uauá' as Municipio union all
	select 'BA' as Estado, 'Ubaíra' as Municipio union all
	select 'BA' as Estado, 'Ubaitaba' as Municipio union all
	select 'BA' as Estado, 'Ubatã' as Municipio union all
	select 'BA' as Estado, 'Uibaí' as Municipio union all
	select 'BA' as Estado, 'Umburanas' as Municipio union all
	select 'BA' as Estado, 'Una' as Municipio union all
	select 'BA' as Estado, 'Urandi' as Municipio union all
	select 'BA' as Estado, 'Uruçuca' as Municipio union all
	select 'BA' as Estado, 'Utinga' as Municipio union all
	select 'BA' as Estado, 'Valença' as Municipio union all
	select 'BA' as Estado, 'Valente' as Municipio union all
	select 'BA' as Estado, 'Várzea da Roça' as Municipio union all
	select 'BA' as Estado, 'Várzea do Poço' as Municipio union all
	select 'BA' as Estado, 'Várzea Nova' as Municipio union all
	select 'BA' as Estado, 'Varzedo' as Municipio union all
	select 'BA' as Estado, 'Vera Cruz' as Municipio union all
	select 'BA' as Estado, 'Vereda' as Municipio union all
	select 'BA' as Estado, 'Vitória da Conquista' as Municipio union all
	select 'BA' as Estado, 'Wagner' as Municipio union all
	select 'BA' as Estado, 'Wanderley' as Municipio union all
	select 'BA' as Estado, 'Wenceslau Guimarães' as Municipio union all
	select 'BA' as Estado, 'Xique-Xique' as Municipio union all
	select 'MG' as Estado, 'Abadia dos Dourados' as Municipio union all
	select 'MG' as Estado, 'Abaeté' as Municipio union all
	select 'MG' as Estado, 'Abre Campo' as Municipio union all
	select 'MG' as Estado, 'Acaiaca' as Municipio union all
	select 'MG' as Estado, 'Açucena' as Municipio union all
	select 'MG' as Estado, 'Água Boa' as Municipio union all
	select 'MG' as Estado, 'Água Comprida' as Municipio union all
	select 'MG' as Estado, 'Aguanil' as Municipio union all
	select 'MG' as Estado, 'Águas Formosas' as Municipio union all
	select 'MG' as Estado, 'Águas Vermelhas' as Municipio union all
	select 'MG' as Estado, 'Aimorés' as Municipio union all
	select 'MG' as Estado, 'Aiuruoca' as Municipio union all
	select 'MG' as Estado, 'Alagoa' as Municipio union all
	select 'MG' as Estado, 'Albertina' as Municipio union all
	select 'MG' as Estado, 'Além Paraíba' as Municipio union all
	select 'MG' as Estado, 'Alfenas' as Municipio union all
	select 'MG' as Estado, 'Alfredo Vasconcelos' as Municipio union all
	select 'MG' as Estado, 'Almenara' as Municipio union all
	select 'MG' as Estado, 'Alpercata' as Municipio union all
	select 'MG' as Estado, 'Alpinópolis' as Municipio union all
	select 'MG' as Estado, 'Alterosa' as Municipio union all
	select 'MG' as Estado, 'Alto Caparaó' as Municipio union all
	select 'MG' as Estado, 'Alto Jequitibá' as Municipio union all
	select 'MG' as Estado, 'Alto Rio Doce' as Municipio union all
	select 'MG' as Estado, 'Alvarenga' as Municipio union all
	select 'MG' as Estado, 'Alvinópolis' as Municipio union all
	select 'MG' as Estado, 'Alvorada de Minas' as Municipio union all
	select 'MG' as Estado, 'Amparo do Serra' as Municipio union all
	select 'MG' as Estado, 'Andradas' as Municipio union all
	select 'MG' as Estado, 'Andrelândia' as Municipio union all
	select 'MG' as Estado, 'Angelândia' as Municipio union all
	select 'MG' as Estado, 'Antônio Carlos' as Municipio union all
	select 'MG' as Estado, 'Antônio Dias' as Municipio union all
	select 'MG' as Estado, 'Antônio Prado de Minas' as Municipio union all
	select 'MG' as Estado, 'Araçaí' as Municipio union all
	select 'MG' as Estado, 'Aracitaba' as Municipio union all
	select 'MG' as Estado, 'Araçuaí' as Municipio union all
	select 'MG' as Estado, 'Araguari' as Municipio union all
	select 'MG' as Estado, 'Arantina' as Municipio union all
	select 'MG' as Estado, 'Araponga' as Municipio union all
	select 'MG' as Estado, 'Araporã' as Municipio union all
	select 'MG' as Estado, 'Arapuá' as Municipio union all
	select 'MG' as Estado, 'Araújos' as Municipio union all
	select 'MG' as Estado, 'Araxá' as Municipio union all
	select 'MG' as Estado, 'Arceburgo' as Municipio union all
	select 'MG' as Estado, 'Arcos' as Municipio union all
	select 'MG' as Estado, 'Areado' as Municipio union all
	select 'MG' as Estado, 'Argirita' as Municipio union all
	select 'MG' as Estado, 'Aricanduva' as Municipio union all
	select 'MG' as Estado, 'Arinos' as Municipio union all
	select 'MG' as Estado, 'Astolfo Dutra' as Municipio union all
	select 'MG' as Estado, 'Ataléia' as Municipio union all
	select 'MG' as Estado, 'Augusto de Lima' as Municipio union all
	select 'MG' as Estado, 'Baependi' as Municipio union all
	select 'MG' as Estado, 'Baldim' as Municipio union all
	select 'MG' as Estado, 'Bambuí' as Municipio union all
	select 'MG' as Estado, 'Bandeira' as Municipio union all
	select 'MG' as Estado, 'Bandeira do Sul' as Municipio union all
	select 'MG' as Estado, 'Barão de Cocais' as Municipio union all
	select 'MG' as Estado, 'Barão de Monte Alto' as Municipio union all
	select 'MG' as Estado, 'Barbacena' as Municipio union all
	select 'MG' as Estado, 'Barra Longa' as Municipio union all
	select 'MG' as Estado, 'Barroso' as Municipio union all
	select 'MG' as Estado, 'Bela Vista de Minas' as Municipio union all
	select 'MG' as Estado, 'Belmiro Braga' as Municipio union all
	select 'MG' as Estado, 'Belo Horizonte' as Municipio union all
	select 'MG' as Estado, 'Belo Oriente' as Municipio union all
	select 'MG' as Estado, 'Belo Vale' as Municipio union all
	select 'MG' as Estado, 'Berilo' as Municipio union all
	select 'MG' as Estado, 'Berizal' as Municipio union all
	select 'MG' as Estado, 'Bertópolis' as Municipio union all
	select 'MG' as Estado, 'Betim' as Municipio union all
	select 'MG' as Estado, 'Bias Fortes' as Municipio union all
	select 'MG' as Estado, 'Bicas' as Municipio union all
	select 'MG' as Estado, 'Biquinhas' as Municipio union all
	select 'MG' as Estado, 'Boa Esperança' as Municipio union all
	select 'MG' as Estado, 'Bocaina de Minas' as Municipio union all
	select 'MG' as Estado, 'Bocaiúva' as Municipio union all
	select 'MG' as Estado, 'Bom Despacho' as Municipio union all
	select 'MG' as Estado, 'Bom Jardim de Minas' as Municipio union all
	select 'MG' as Estado, 'Bom Jesus da Penha' as Municipio union all
	select 'MG' as Estado, 'Bom Jesus do Amparo' as Municipio union all
	select 'MG' as Estado, 'Bom Jesus do Galho' as Municipio union all
	select 'MG' as Estado, 'Bom Repouso' as Municipio union all
	select 'MG' as Estado, 'Bom Sucesso' as Municipio union all
	select 'MG' as Estado, 'Bonfim' as Municipio union all
	select 'MG' as Estado, 'Bonfinópolis de Minas' as Municipio union all
	select 'MG' as Estado, 'Bonito de Minas' as Municipio union all
	select 'MG' as Estado, 'Borda da Mata' as Municipio union all
	select 'MG' as Estado, 'Botelhos' as Municipio union all
	select 'MG' as Estado, 'Botumirim' as Municipio union all
	select 'MG' as Estado, 'Brás Pires' as Municipio union all
	select 'MG' as Estado, 'Brasilândia de Minas' as Municipio union all
	select 'MG' as Estado, 'Brasília de Minas' as Municipio union all
	select 'MG' as Estado, 'Brasópolis' as Municipio union all
	select 'MG' as Estado, 'Braúnas' as Municipio union all
	select 'MG' as Estado, 'Brumadinho' as Municipio union all
	select 'MG' as Estado, 'Bueno Brandão' as Municipio union all
	select 'MG' as Estado, 'Buenópolis' as Municipio union all
	select 'MG' as Estado, 'Bugre' as Municipio union all
	select 'MG' as Estado, 'Buritis' as Municipio union all
	select 'MG' as Estado, 'Buritizeiro' as Municipio union all
	select 'MG' as Estado, 'Cabeceira Grande' as Municipio union all
	select 'MG' as Estado, 'Cabo Verde' as Municipio union all
	select 'MG' as Estado, 'Cachoeira da Prata' as Municipio union all
	select 'MG' as Estado, 'Cachoeira de Minas' as Municipio union all
	select 'MG' as Estado, 'Cachoeira de Pajeú' as Municipio union all
	select 'MG' as Estado, 'Cachoeira Dourada' as Municipio union all
	select 'MG' as Estado, 'Caetanópolis' as Municipio union all
	select 'MG' as Estado, 'Caeté' as Municipio union all
	select 'MG' as Estado, 'Caiana' as Municipio union all
	select 'MG' as Estado, 'Cajuri' as Municipio union all
	select 'MG' as Estado, 'Caldas' as Municipio union all
	select 'MG' as Estado, 'Camacho' as Municipio union all
	select 'MG' as Estado, 'Camanducaia' as Municipio union all
	select 'MG' as Estado, 'Cambuí' as Municipio union all
	select 'MG' as Estado, 'Cambuquira' as Municipio union all
	select 'MG' as Estado, 'Campanário' as Municipio union all
	select 'MG' as Estado, 'Campanha' as Municipio union all
	select 'MG' as Estado, 'Campestre' as Municipio union all
	select 'MG' as Estado, 'Campina Verde' as Municipio union all
	select 'MG' as Estado, 'Campo Azul' as Municipio union all
	select 'MG' as Estado, 'Campo Belo' as Municipio union all
	select 'MG' as Estado, 'Campo do Meio' as Municipio union all
	select 'MG' as Estado, 'Campo Florido' as Municipio union all
	select 'MG' as Estado, 'Campos Altos' as Municipio union all
	select 'MG' as Estado, 'Campos Gerais' as Municipio union all
	select 'MG' as Estado, 'Cana Verde' as Municipio union all
	select 'MG' as Estado, 'Canaã' as Municipio union all
	select 'MG' as Estado, 'Canápolis' as Municipio union all
	select 'MG' as Estado, 'Candeias' as Municipio union all
	select 'MG' as Estado, 'Cantagalo' as Municipio union all
	select 'MG' as Estado, 'Caparaó' as Municipio union all
	select 'MG' as Estado, 'Capela Nova' as Municipio union all
	select 'MG' as Estado, 'Capelinha' as Municipio union all
	select 'MG' as Estado, 'Capetinga' as Municipio union all
	select 'MG' as Estado, 'Capim Branco' as Municipio union all
	select 'MG' as Estado, 'Capinópolis' as Municipio union all
	select 'MG' as Estado, 'Capitão Andrade' as Municipio union all
	select 'MG' as Estado, 'Capitão Enéas' as Municipio union all
	select 'MG' as Estado, 'Capitólio' as Municipio union all
	select 'MG' as Estado, 'Caputira' as Municipio union all
	select 'MG' as Estado, 'Caraí' as Municipio union all
	select 'MG' as Estado, 'Caranaíba' as Municipio union all
	select 'MG' as Estado, 'Carandaí' as Municipio union all
	select 'MG' as Estado, 'Carangola' as Municipio union all
	select 'MG' as Estado, 'Caratinga' as Municipio union all
	select 'MG' as Estado, 'Carbonita' as Municipio union all
	select 'MG' as Estado, 'Careaçu' as Municipio union all
	select 'MG' as Estado, 'Carlos Chagas' as Municipio union all
	select 'MG' as Estado, 'Carmésia' as Municipio union all
	select 'MG' as Estado, 'Carmo da Cachoeira' as Municipio union all
	select 'MG' as Estado, 'Carmo da Mata' as Municipio union all
	select 'MG' as Estado, 'Carmo de Minas' as Municipio union all
	select 'MG' as Estado, 'Carmo do Cajuru' as Municipio union all
	select 'MG' as Estado, 'Carmo do Paranaíba' as Municipio union all
	select 'MG' as Estado, 'Carmo do Rio Claro' as Municipio union all
	select 'MG' as Estado, 'Carmópolis de Minas' as Municipio union all
	select 'MG' as Estado, 'Carneirinho' as Municipio union all
	select 'MG' as Estado, 'Carrancas' as Municipio union all
	select 'MG' as Estado, 'Carvalhópolis' as Municipio union all
	select 'MG' as Estado, 'Carvalhos' as Municipio union all
	select 'MG' as Estado, 'Casa Grande' as Municipio union all
	select 'MG' as Estado, 'Cascalho Rico' as Municipio union all
	select 'MG' as Estado, 'Cássia' as Municipio union all
	select 'MG' as Estado, 'Cataguases' as Municipio union all
	select 'MG' as Estado, 'Catas Altas' as Municipio union all
	select 'MG' as Estado, 'Catas Altas da Noruega' as Municipio union all
	select 'MG' as Estado, 'Catuji' as Municipio union all
	select 'MG' as Estado, 'Catuti' as Municipio union all
	select 'MG' as Estado, 'Caxambu' as Municipio union all
	select 'MG' as Estado, 'Cedro do Abaeté' as Municipio union all
	select 'MG' as Estado, 'Central de Minas' as Municipio union all
	select 'MG' as Estado, 'Centralina' as Municipio union all
	select 'MG' as Estado, 'Chácara' as Municipio union all
	select 'MG' as Estado, 'Chalé' as Municipio union all
	select 'MG' as Estado, 'Chapada do Norte' as Municipio union all
	select 'MG' as Estado, 'Chapada Gaúcha' as Municipio union all
	select 'MG' as Estado, 'Chiador' as Municipio union all
	select 'MG' as Estado, 'Cipotânea' as Municipio union all
	select 'MG' as Estado, 'Claraval' as Municipio union all
	select 'MG' as Estado, 'Claro dos Poções' as Municipio union all
	select 'MG' as Estado, 'Cláudio' as Municipio union all
	select 'MG' as Estado, 'Coimbra' as Municipio union all
	select 'MG' as Estado, 'Coluna' as Municipio union all
	select 'MG' as Estado, 'Comendador Gomes' as Municipio union all
	select 'MG' as Estado, 'Comercinho' as Municipio union all
	select 'MG' as Estado, 'Conceição da Aparecida' as Municipio union all
	select 'MG' as Estado, 'Conceição da Barra de Minas' as Municipio union all
	select 'MG' as Estado, 'Conceição das Alagoas' as Municipio union all
	select 'MG' as Estado, 'Conceição das Pedras' as Municipio union all
	select 'MG' as Estado, 'Conceição de Ipanema' as Municipio union all
	select 'MG' as Estado, 'Conceição do Mato Dentro' as Municipio union all
	select 'MG' as Estado, 'Conceição do Pará' as Municipio union all
	select 'MG' as Estado, 'Conceição do Rio Verde' as Municipio union all
	select 'MG' as Estado, 'Conceição dos Ouros' as Municipio union all
	select 'MG' as Estado, 'Cônego Marinho' as Municipio union all
	select 'MG' as Estado, 'Confins' as Municipio union all
	select 'MG' as Estado, 'Congonhal' as Municipio union all
	select 'MG' as Estado, 'Congonhas' as Municipio union all
	select 'MG' as Estado, 'Congonhas do Norte' as Municipio union all
	select 'MG' as Estado, 'Conquista' as Municipio union all
	select 'MG' as Estado, 'Conselheiro Lafaiete' as Municipio union all
	select 'MG' as Estado, 'Conselheiro Pena' as Municipio union all
	select 'MG' as Estado, 'Consolação' as Municipio union all
	select 'MG' as Estado, 'Contagem' as Municipio union all
	select 'MG' as Estado, 'Coqueiral' as Municipio union all
	select 'MG' as Estado, 'Coração de Jesus' as Municipio union all
	select 'MG' as Estado, 'Cordisburgo' as Municipio union all
	select 'MG' as Estado, 'Cordislândia' as Municipio union all
	select 'MG' as Estado, 'Corinto' as Municipio union all
	select 'MG' as Estado, 'Coroaci' as Municipio union all
	select 'MG' as Estado, 'Coromandel' as Municipio union all
	select 'MG' as Estado, 'Coronel Fabriciano' as Municipio union all
	select 'MG' as Estado, 'Coronel Murta' as Municipio union all
	select 'MG' as Estado, 'Coronel Pacheco' as Municipio union all
	select 'MG' as Estado, 'Coronel Xavier Chaves' as Municipio union all
	select 'MG' as Estado, 'Córrego Danta' as Municipio union all
	select 'MG' as Estado, 'Córrego do Bom Jesus' as Municipio union all
	select 'MG' as Estado, 'Córrego Fundo' as Municipio union all
	select 'MG' as Estado, 'Córrego Novo' as Municipio union all
	select 'MG' as Estado, 'Couto de Magalhães de Minas' as Municipio union all
	select 'MG' as Estado, 'Crisólita' as Municipio union all
	select 'MG' as Estado, 'Cristais' as Municipio union all
	select 'MG' as Estado, 'Cristália' as Municipio union all
	select 'MG' as Estado, 'Cristiano Otoni' as Municipio union all
	select 'MG' as Estado, 'Cristina' as Municipio union all
	select 'MG' as Estado, 'Crucilândia' as Municipio union all
	select 'MG' as Estado, 'Cruzeiro da Fortaleza' as Municipio union all
	select 'MG' as Estado, 'Cruzília' as Municipio union all
	select 'MG' as Estado, 'Cuparaque' as Municipio union all
	select 'MG' as Estado, 'Curral de Dentro' as Municipio union all
	select 'MG' as Estado, 'Curvelo' as Municipio union all
	select 'MG' as Estado, 'Datas' as Municipio union all
	select 'MG' as Estado, 'Delfim Moreira' as Municipio union all
	select 'MG' as Estado, 'Delfinópolis' as Municipio union all
	select 'MG' as Estado, 'Delta' as Municipio union all
	select 'MG' as Estado, 'Descoberto' as Municipio union all
	select 'MG' as Estado, 'Desterro de Entre Rios' as Municipio union all
	select 'MG' as Estado, 'Desterro do Melo' as Municipio union all
	select 'MG' as Estado, 'Diamantina' as Municipio union all
	select 'MG' as Estado, 'Diogo de Vasconcelos' as Municipio union all
	select 'MG' as Estado, 'Dionísio' as Municipio union all
	select 'MG' as Estado, 'Divinésia' as Municipio union all
	select 'MG' as Estado, 'Divino' as Municipio union all
	select 'MG' as Estado, 'Divino das Laranjeiras' as Municipio union all
	select 'MG' as Estado, 'Divinolândia de Minas' as Municipio union all
	select 'MG' as Estado, 'Divinópolis' as Municipio union all
	select 'MG' as Estado, 'Divisa Alegre' as Municipio union all
	select 'MG' as Estado, 'Divisa Nova' as Municipio union all
	select 'MG' as Estado, 'Divisópolis' as Municipio union all
	select 'MG' as Estado, 'Dom Bosco' as Municipio union all
	select 'MG' as Estado, 'Dom Cavati' as Municipio union all
	select 'MG' as Estado, 'Dom Joaquim' as Municipio union all
	select 'MG' as Estado, 'Dom Silvério' as Municipio union all
	select 'MG' as Estado, 'Dom Viçoso' as Municipio union all
	select 'MG' as Estado, 'Dona Eusébia' as Municipio union all
	select 'MG' as Estado, 'Dores de Campos' as Municipio union all
	select 'MG' as Estado, 'Dores de Guanhães' as Municipio union all
	select 'MG' as Estado, 'Dores do Indaiá' as Municipio union all
	select 'MG' as Estado, 'Dores do Turvo' as Municipio union all
	select 'MG' as Estado, 'Doresópolis' as Municipio union all
	select 'MG' as Estado, 'Douradoquara' as Municipio union all
	select 'MG' as Estado, 'Durandé' as Municipio union all
	select 'MG' as Estado, 'Elói Mendes' as Municipio union all
	select 'MG' as Estado, 'Engenheiro Caldas' as Municipio union all
	select 'MG' as Estado, 'Engenheiro Navarro' as Municipio union all
	select 'MG' as Estado, 'Entre Folhas' as Municipio union all
	select 'MG' as Estado, 'Entre Rios de Minas' as Municipio union all
	select 'MG' as Estado, 'Ervália' as Municipio union all
	select 'MG' as Estado, 'Esmeraldas' as Municipio union all
	select 'MG' as Estado, 'Espera Feliz' as Municipio union all
	select 'MG' as Estado, 'Espinosa' as Municipio union all
	select 'MG' as Estado, 'Espírito Santo do Dourado' as Municipio union all
	select 'MG' as Estado, 'Estiva' as Municipio union all
	select 'MG' as Estado, 'Estrela Dalva' as Municipio union all
	select 'MG' as Estado, 'Estrela do Indaiá' as Municipio union all
	select 'MG' as Estado, 'Estrela do Sul' as Municipio union all
	select 'MG' as Estado, 'Eugenópolis' as Municipio union all
	select 'MG' as Estado, 'Ewbank da Câmara' as Municipio union all
	select 'MG' as Estado, 'Extrema' as Municipio union all
	select 'MG' as Estado, 'Fama' as Municipio union all
	select 'MG' as Estado, 'Faria Lemos' as Municipio union all
	select 'MG' as Estado, 'Felício dos Santos' as Municipio union all
	select 'MG' as Estado, 'Felisburgo' as Municipio union all
	select 'MG' as Estado, 'Felixlândia' as Municipio union all
	select 'MG' as Estado, 'Fernandes Tourinho' as Municipio union all
	select 'MG' as Estado, 'Ferros' as Municipio union all
	select 'MG' as Estado, 'Fervedouro' as Municipio union all
	select 'MG' as Estado, 'Florestal' as Municipio union all
	select 'MG' as Estado, 'Formiga' as Municipio union all
	select 'MG' as Estado, 'Formoso' as Municipio union all
	select 'MG' as Estado, 'Fortaleza de Minas' as Municipio union all
	select 'MG' as Estado, 'Fortuna de Minas' as Municipio union all
	select 'MG' as Estado, 'Francisco Badaró' as Municipio union all
	select 'MG' as Estado, 'Francisco Dumont' as Municipio union all
	select 'MG' as Estado, 'Francisco Sá' as Municipio union all
	select 'MG' as Estado, 'Franciscópolis' as Municipio union all
	select 'MG' as Estado, 'Frei Gaspar' as Municipio union all
	select 'MG' as Estado, 'Frei Inocêncio' as Municipio union all
	select 'MG' as Estado, 'Frei Lagonegro' as Municipio union all
	select 'MG' as Estado, 'Fronteira' as Municipio union all
	select 'MG' as Estado, 'Fronteira dos Vales' as Municipio union all
	select 'MG' as Estado, 'Fruta de Leite' as Municipio union all
	select 'MG' as Estado, 'Frutal' as Municipio union all
	select 'MG' as Estado, 'Funilândia' as Municipio union all
	select 'MG' as Estado, 'Galiléia' as Municipio union all
	select 'MG' as Estado, 'Gameleiras' as Municipio union all
	select 'MG' as Estado, 'Glaucilândia' as Municipio union all
	select 'MG' as Estado, 'Goiabeira' as Municipio union all
	select 'MG' as Estado, 'Goianá' as Municipio union all
	select 'MG' as Estado, 'Gonçalves' as Municipio union all
	select 'MG' as Estado, 'Gonzaga' as Municipio union all
	select 'MG' as Estado, 'Gouveia' as Municipio union all
	select 'MG' as Estado, 'Governador Valadares' as Municipio union all
	select 'MG' as Estado, 'Grão Mogol' as Municipio union all
	select 'MG' as Estado, 'Grupiara' as Municipio union all
	select 'MG' as Estado, 'Guanhães' as Municipio union all
	select 'MG' as Estado, 'Guapé' as Municipio union all
	select 'MG' as Estado, 'Guaraciaba' as Municipio union all
	select 'MG' as Estado, 'Guaraciama' as Municipio union all
	select 'MG' as Estado, 'Guaranésia' as Municipio union all
	select 'MG' as Estado, 'Guarani' as Municipio union all
	select 'MG' as Estado, 'Guarará' as Municipio union all
	select 'MG' as Estado, 'Guarda-Mor' as Municipio union all
	select 'MG' as Estado, 'Guaxupé' as Municipio union all
	select 'MG' as Estado, 'Guidoval' as Municipio union all
	select 'MG' as Estado, 'Guimarânia' as Municipio union all
	select 'MG' as Estado, 'Guiricema' as Municipio union all
	select 'MG' as Estado, 'Gurinhatã' as Municipio union all
	select 'MG' as Estado, 'Heliodora' as Municipio union all
	select 'MG' as Estado, 'Iapu' as Municipio union all
	select 'MG' as Estado, 'Ibertioga' as Municipio union all
	select 'MG' as Estado, 'Ibiá' as Municipio union all
	select 'MG' as Estado, 'Ibiaí' as Municipio union all
	select 'MG' as Estado, 'Ibiracatu' as Municipio union all
	select 'MG' as Estado, 'Ibiraci' as Municipio union all
	select 'MG' as Estado, 'Ibirité' as Municipio union all
	select 'MG' as Estado, 'Ibitiúra de Minas' as Municipio union all
	select 'MG' as Estado, 'Ibituruna' as Municipio union all
	select 'MG' as Estado, 'Icaraí de Minas' as Municipio union all
	select 'MG' as Estado, 'Igarapé' as Municipio union all
	select 'MG' as Estado, 'Igaratinga' as Municipio union all
	select 'MG' as Estado, 'Iguatama' as Municipio union all
	select 'MG' as Estado, 'Ijaci' as Municipio union all
	select 'MG' as Estado, 'Ilicínea' as Municipio union all
	select 'MG' as Estado, 'Imbé de Minas' as Municipio union all
	select 'MG' as Estado, 'Inconfidentes' as Municipio union all
	select 'MG' as Estado, 'Indaiabira' as Municipio union all
	select 'MG' as Estado, 'Indianópolis' as Municipio union all
	select 'MG' as Estado, 'Ingaí' as Municipio union all
	select 'MG' as Estado, 'Inhapim' as Municipio union all
	select 'MG' as Estado, 'Inhaúma' as Municipio union all
	select 'MG' as Estado, 'Inimutaba' as Municipio union all
	select 'MG' as Estado, 'Ipaba' as Municipio union all
	select 'MG' as Estado, 'Ipanema' as Municipio union all
	select 'MG' as Estado, 'Ipatinga' as Municipio union all
	select 'MG' as Estado, 'Ipiaçu' as Municipio union all
	select 'MG' as Estado, 'Ipuiúna' as Municipio union all
	select 'MG' as Estado, 'Iraí de Minas' as Municipio union all
	select 'MG' as Estado, 'Itabira' as Municipio union all
	select 'MG' as Estado, 'Itabirinha' as Municipio union all
	select 'MG' as Estado, 'Itabirito' as Municipio union all
	select 'MG' as Estado, 'Itacambira' as Municipio union all
	select 'MG' as Estado, 'Itacarambi' as Municipio union all
	select 'MG' as Estado, 'Itaguara' as Municipio union all
	select 'MG' as Estado, 'Itaipé' as Municipio union all
	select 'MG' as Estado, 'Itajubá' as Municipio union all
	select 'MG' as Estado, 'Itamarandiba' as Municipio union all
	select 'MG' as Estado, 'Itamarati de Minas' as Municipio union all
	select 'MG' as Estado, 'Itambacuri' as Municipio union all
	select 'MG' as Estado, 'Itambé do Mato Dentro' as Municipio union all
	select 'MG' as Estado, 'Itamogi' as Municipio union all
	select 'MG' as Estado, 'Itamonte' as Municipio union all
	select 'MG' as Estado, 'Itanhandu' as Municipio union all
	select 'MG' as Estado, 'Itanhomi' as Municipio union all
	select 'MG' as Estado, 'Itaobim' as Municipio union all
	select 'MG' as Estado, 'Itapagipe' as Municipio union all
	select 'MG' as Estado, 'Itapecerica' as Municipio union all
	select 'MG' as Estado, 'Itapeva' as Municipio union all
	select 'MG' as Estado, 'Itatiaiuçu' as Municipio union all
	select 'MG' as Estado, 'Itaú de Minas' as Municipio union all
	select 'MG' as Estado, 'Itaúna' as Municipio union all
	select 'MG' as Estado, 'Itaverava' as Municipio union all
	select 'MG' as Estado, 'Itinga' as Municipio union all
	select 'MG' as Estado, 'Itueta' as Municipio union all
	select 'MG' as Estado, 'Ituiutaba' as Municipio union all
	select 'MG' as Estado, 'Itumirim' as Municipio union all
	select 'MG' as Estado, 'Iturama' as Municipio union all
	select 'MG' as Estado, 'Itutinga' as Municipio union all
	select 'MG' as Estado, 'Jaboticatubas' as Municipio union all
	select 'MG' as Estado, 'Jacinto' as Municipio union all
	select 'MG' as Estado, 'Jacuí' as Municipio union all
	select 'MG' as Estado, 'Jacutinga' as Municipio union all
	select 'MG' as Estado, 'Jaguaraçu' as Municipio union all
	select 'MG' as Estado, 'Jaíba' as Municipio union all
	select 'MG' as Estado, 'Jampruca' as Municipio union all
	select 'MG' as Estado, 'Janaúba' as Municipio union all
	select 'MG' as Estado, 'Januária' as Municipio union all
	select 'MG' as Estado, 'Japaraíba' as Municipio union all
	select 'MG' as Estado, 'Japonvar' as Municipio union all
	select 'MG' as Estado, 'Jeceaba' as Municipio union all
	select 'MG' as Estado, 'Jenipapo de Minas' as Municipio union all
	select 'MG' as Estado, 'Jequeri' as Municipio union all
	select 'MG' as Estado, 'Jequitaí' as Municipio union all
	select 'MG' as Estado, 'Jequitibá' as Municipio union all
	select 'MG' as Estado, 'Jequitinhonha' as Municipio union all
	select 'MG' as Estado, 'Jesuânia' as Municipio union all
	select 'MG' as Estado, 'Joaíma' as Municipio union all
	select 'MG' as Estado, 'Joanésia' as Municipio union all
	select 'MG' as Estado, 'João Monlevade' as Municipio union all
	select 'MG' as Estado, 'João Pinheiro' as Municipio union all
	select 'MG' as Estado, 'Joaquim Felício' as Municipio union all
	select 'MG' as Estado, 'Jordânia' as Municipio union all
	select 'MG' as Estado, 'José Gonçalves de Minas' as Municipio union all
	select 'MG' as Estado, 'José Raydan' as Municipio union all
	select 'MG' as Estado, 'Josenópolis' as Municipio union all
	select 'MG' as Estado, 'Juatuba' as Municipio union all
	select 'MG' as Estado, 'Juiz de Fora' as Municipio union all
	select 'MG' as Estado, 'Juramento' as Municipio union all
	select 'MG' as Estado, 'Juruaia' as Municipio union all
	select 'MG' as Estado, 'Juvenília' as Municipio union all
	select 'MG' as Estado, 'Ladainha' as Municipio union all
	select 'MG' as Estado, 'Lagamar' as Municipio union all
	select 'MG' as Estado, 'Lagoa da Prata' as Municipio union all
	select 'MG' as Estado, 'Lagoa dos Patos' as Municipio union all
	select 'MG' as Estado, 'Lagoa Dourada' as Municipio union all
	select 'MG' as Estado, 'Lagoa Formosa' as Municipio union all
	select 'MG' as Estado, 'Lagoa Grande' as Municipio union all
	select 'MG' as Estado, 'Lagoa Santa' as Municipio union all
	select 'MG' as Estado, 'Lajinha' as Municipio union all
	select 'MG' as Estado, 'Lambari' as Municipio union all
	select 'MG' as Estado, 'Lamim' as Municipio union all
	select 'MG' as Estado, 'Laranjal' as Municipio union all
	select 'MG' as Estado, 'Lassance' as Municipio union all
	select 'MG' as Estado, 'Lavras' as Municipio union all
	select 'MG' as Estado, 'Leandro Ferreira' as Municipio union all
	select 'MG' as Estado, 'Leme do Prado' as Municipio union all
	select 'MG' as Estado, 'Leopoldina' as Municipio union all
	select 'MG' as Estado, 'Liberdade' as Municipio union all
	select 'MG' as Estado, 'Lima Duarte' as Municipio union all
	select 'MG' as Estado, 'Limeira do Oeste' as Municipio union all
	select 'MG' as Estado, 'Lontra' as Municipio union all
	select 'MG' as Estado, 'Luisburgo' as Municipio union all
	select 'MG' as Estado, 'Luislândia' as Municipio union all
	select 'MG' as Estado, 'Luminárias' as Municipio union all
	select 'MG' as Estado, 'Luz' as Municipio union all
	select 'MG' as Estado, 'Machacalis' as Municipio union all
	select 'MG' as Estado, 'Machado' as Municipio union all
	select 'MG' as Estado, 'Madre de Deus de Minas' as Municipio union all
	select 'MG' as Estado, 'Malacacheta' as Municipio union all
	select 'MG' as Estado, 'Mamonas' as Municipio union all
	select 'MG' as Estado, 'Manga' as Municipio union all
	select 'MG' as Estado, 'Manhuaçu' as Municipio union all
	select 'MG' as Estado, 'Manhumirim' as Municipio union all
	select 'MG' as Estado, 'Mantena' as Municipio union all
	select 'MG' as Estado, 'Mar de Espanha' as Municipio union all
	select 'MG' as Estado, 'Maravilhas' as Municipio union all
	select 'MG' as Estado, 'Maria da Fé' as Municipio union all
	select 'MG' as Estado, 'Mariana' as Municipio union all
	select 'MG' as Estado, 'Marilac' as Municipio union all
	select 'MG' as Estado, 'Mário Campos' as Municipio union all
	select 'MG' as Estado, 'Maripá de Minas' as Municipio union all
	select 'MG' as Estado, 'Marliéria' as Municipio union all
	select 'MG' as Estado, 'Marmelópolis' as Municipio union all
	select 'MG' as Estado, 'Martinho Campos' as Municipio union all
	select 'MG' as Estado, 'Martins Soares' as Municipio union all
	select 'MG' as Estado, 'Mata Verde' as Municipio union all
	select 'MG' as Estado, 'Materlândia' as Municipio union all
	select 'MG' as Estado, 'Mateus Leme' as Municipio union all
	select 'MG' as Estado, 'Mathias Lobato' as Municipio union all
	select 'MG' as Estado, 'Matias Barbosa' as Municipio union all
	select 'MG' as Estado, 'Matias Cardoso' as Municipio union all
	select 'MG' as Estado, 'Matipó' as Municipio union all
	select 'MG' as Estado, 'Mato Verde' as Municipio union all
	select 'MG' as Estado, 'Matozinhos' as Municipio union all
	select 'MG' as Estado, 'Matutina' as Municipio union all
	select 'MG' as Estado, 'Medeiros' as Municipio union all
	select 'MG' as Estado, 'Medina' as Municipio union all
	select 'MG' as Estado, 'Mendes Pimentel' as Municipio union all
	select 'MG' as Estado, 'Mercês' as Municipio union all
	select 'MG' as Estado, 'Mesquita' as Municipio union all
	select 'MG' as Estado, 'Minas Novas' as Municipio union all
	select 'MG' as Estado, 'Minduri' as Municipio union all
	select 'MG' as Estado, 'Mirabela' as Municipio union all
	select 'MG' as Estado, 'Miradouro' as Municipio union all
	select 'MG' as Estado, 'Miraí' as Municipio union all
	select 'MG' as Estado, 'Miravânia' as Municipio union all
	select 'MG' as Estado, 'Moeda' as Municipio union all
	select 'MG' as Estado, 'Moema' as Municipio union all
	select 'MG' as Estado, 'Monjolos' as Municipio union all
	select 'MG' as Estado, 'Monsenhor Paulo' as Municipio union all
	select 'MG' as Estado, 'Montalvânia' as Municipio union all
	select 'MG' as Estado, 'Monte Alegre de Minas' as Municipio union all
	select 'MG' as Estado, 'Monte Azul' as Municipio union all
	select 'MG' as Estado, 'Monte Belo' as Municipio union all
	select 'MG' as Estado, 'Monte Carmelo' as Municipio union all
	select 'MG' as Estado, 'Monte Formoso' as Municipio union all
	select 'MG' as Estado, 'Monte Santo de Minas' as Municipio union all
	select 'MG' as Estado, 'Monte Sião' as Municipio union all
	select 'MG' as Estado, 'Montes Claros' as Municipio union all
	select 'MG' as Estado, 'Montezuma' as Municipio union all
	select 'MG' as Estado, 'Morada Nova de Minas' as Municipio union all
	select 'MG' as Estado, 'Morro da Garça' as Municipio union all
	select 'MG' as Estado, 'Morro do Pilar' as Municipio union all
	select 'MG' as Estado, 'Munhoz' as Municipio union all
	select 'MG' as Estado, 'Muriaé' as Municipio union all
	select 'MG' as Estado, 'Mutum' as Municipio union all
	select 'MG' as Estado, 'Muzambinho' as Municipio union all
	select 'MG' as Estado, 'Nacip Raydan' as Municipio union all
	select 'MG' as Estado, 'Nanuque' as Municipio union all
	select 'MG' as Estado, 'Naque' as Municipio union all
	select 'MG' as Estado, 'Natalândia' as Municipio union all
	select 'MG' as Estado, 'Natércia' as Municipio union all
	select 'MG' as Estado, 'Nazareno' as Municipio union all
	select 'MG' as Estado, 'Nepomuceno' as Municipio union all
	select 'MG' as Estado, 'Ninheira' as Municipio union all
	select 'MG' as Estado, 'Nova Belém' as Municipio union all
	select 'MG' as Estado, 'Nova Era' as Municipio union all
	select 'MG' as Estado, 'Nova Lima' as Municipio union all
	select 'MG' as Estado, 'Nova Módica' as Municipio union all
	select 'MG' as Estado, 'Nova Ponte' as Municipio union all
	select 'MG' as Estado, 'Nova Porteirinha' as Municipio union all
	select 'MG' as Estado, 'Nova Resende' as Municipio union all
	select 'MG' as Estado, 'Nova Serrana' as Municipio union all
	select 'MG' as Estado, 'Nova União' as Municipio union all
	select 'MG' as Estado, 'Novo Cruzeiro' as Municipio union all
	select 'MG' as Estado, 'Novo Oriente de Minas' as Municipio union all
	select 'MG' as Estado, 'Novorizonte' as Municipio union all
	select 'MG' as Estado, 'Olaria' as Municipio union all
	select 'MG' as Estado, 'Olhos-d''Água' as Municipio union all
	select 'MG' as Estado, 'Olímpio Noronha' as Municipio union all
	select 'MG' as Estado, 'Oliveira' as Municipio union all
	select 'MG' as Estado, 'Oliveira Fortes' as Municipio union all
	select 'MG' as Estado, 'Onça de Pitangui' as Municipio union all
	select 'MG' as Estado, 'Oratórios' as Municipio union all
	select 'MG' as Estado, 'Orizânia' as Municipio union all
	select 'MG' as Estado, 'Ouro Branco' as Municipio union all
	select 'MG' as Estado, 'Ouro Fino' as Municipio union all
	select 'MG' as Estado, 'Ouro Preto' as Municipio union all
	select 'MG' as Estado, 'Ouro Verde de Minas' as Municipio union all
	select 'MG' as Estado, 'Padre Carvalho' as Municipio union all
	select 'MG' as Estado, 'Padre Paraíso' as Municipio union all
	select 'MG' as Estado, 'Pai Pedro' as Municipio union all
	select 'MG' as Estado, 'Paineiras' as Municipio union all
	select 'MG' as Estado, 'Pains' as Municipio union all
	select 'MG' as Estado, 'Paiva' as Municipio union all
	select 'MG' as Estado, 'Palma' as Municipio union all
	select 'MG' as Estado, 'Palmópolis' as Municipio union all
	select 'MG' as Estado, 'Papagaios' as Municipio union all
	select 'MG' as Estado, 'Pará de Minas' as Municipio union all
	select 'MG' as Estado, 'Paracatu' as Municipio union all
	select 'MG' as Estado, 'Paraguaçu' as Municipio union all
	select 'MG' as Estado, 'Paraisópolis' as Municipio union all
	select 'MG' as Estado, 'Paraopeba' as Municipio union all
	select 'MG' as Estado, 'Passa Quatro' as Municipio union all
	select 'MG' as Estado, 'Passa Tempo' as Municipio union all
	select 'MG' as Estado, 'Passabém' as Municipio union all
	select 'MG' as Estado, 'Passa-Vinte' as Municipio union all
	select 'MG' as Estado, 'Passos' as Municipio union all
	select 'MG' as Estado, 'Patis' as Municipio union all
	select 'MG' as Estado, 'Patos de Minas' as Municipio union all
	select 'MG' as Estado, 'Patrocínio' as Municipio union all
	select 'MG' as Estado, 'Patrocínio do Muriaé' as Municipio union all
	select 'MG' as Estado, 'Paula Cândido' as Municipio union all
	select 'MG' as Estado, 'Paulistas' as Municipio union all
	select 'MG' as Estado, 'Pavão' as Municipio union all
	select 'MG' as Estado, 'Peçanha' as Municipio union all
	select 'MG' as Estado, 'Pedra Azul' as Municipio union all
	select 'MG' as Estado, 'Pedra Bonita' as Municipio union all
	select 'MG' as Estado, 'Pedra do Anta' as Municipio union all
	select 'MG' as Estado, 'Pedra do Indaiá' as Municipio union all
	select 'MG' as Estado, 'Pedra Dourada' as Municipio union all
	select 'MG' as Estado, 'Pedralva' as Municipio union all
	select 'MG' as Estado, 'Pedras de Maria da Cruz' as Municipio union all
	select 'MG' as Estado, 'Pedrinópolis' as Municipio union all
	select 'MG' as Estado, 'Pedro Leopoldo' as Municipio union all
	select 'MG' as Estado, 'Pedro Teixeira' as Municipio union all
	select 'MG' as Estado, 'Pequeri' as Municipio union all
	select 'MG' as Estado, 'Pequi' as Municipio union all
	select 'MG' as Estado, 'Perdigão' as Municipio union all
	select 'MG' as Estado, 'Perdizes' as Municipio union all
	select 'MG' as Estado, 'Perdões' as Municipio union all
	select 'MG' as Estado, 'Periquito' as Municipio union all
	select 'MG' as Estado, 'Pescador' as Municipio union all
	select 'MG' as Estado, 'Piau' as Municipio union all
	select 'MG' as Estado, 'Piedade de Caratinga' as Municipio union all
	select 'MG' as Estado, 'Piedade de Ponte Nova' as Municipio union all
	select 'MG' as Estado, 'Piedade do Rio Grande' as Municipio union all
	select 'MG' as Estado, 'Piedade dos Gerais' as Municipio union all
	select 'MG' as Estado, 'Pimenta' as Municipio union all
	select 'MG' as Estado, 'Pingo-d''Água' as Municipio union all
	select 'MG' as Estado, 'Pintópolis' as Municipio union all
	select 'MG' as Estado, 'Piracema' as Municipio union all
	select 'MG' as Estado, 'Pirajuba' as Municipio union all
	select 'MG' as Estado, 'Piranga' as Municipio union all
	select 'MG' as Estado, 'Piranguçu' as Municipio union all
	select 'MG' as Estado, 'Piranguinho' as Municipio union all
	select 'MG' as Estado, 'Pirapetinga' as Municipio union all
	select 'MG' as Estado, 'Pirapora' as Municipio union all
	select 'MG' as Estado, 'Piraúba' as Municipio union all
	select 'MG' as Estado, 'Pitangui' as Municipio union all
	select 'MG' as Estado, 'Piumhi' as Municipio union all
	select 'MG' as Estado, 'Planura' as Municipio union all
	select 'MG' as Estado, 'Poço Fundo' as Municipio union all
	select 'MG' as Estado, 'Poços de Caldas' as Municipio union all
	select 'MG' as Estado, 'Pocrane' as Municipio union all
	select 'MG' as Estado, 'Pompéu' as Municipio union all
	select 'MG' as Estado, 'Ponte Nova' as Municipio union all
	select 'MG' as Estado, 'Ponto Chique' as Municipio union all
	select 'MG' as Estado, 'Ponto dos Volantes' as Municipio union all
	select 'MG' as Estado, 'Porteirinha' as Municipio union all
	select 'MG' as Estado, 'Porto Firme' as Municipio union all
	select 'MG' as Estado, 'Poté' as Municipio union all
	select 'MG' as Estado, 'Pouso Alegre' as Municipio union all
	select 'MG' as Estado, 'Pouso Alto' as Municipio union all
	select 'MG' as Estado, 'Prados' as Municipio union all
	select 'MG' as Estado, 'Prata' as Municipio union all
	select 'MG' as Estado, 'Pratápolis' as Municipio union all
	select 'MG' as Estado, 'Pratinha' as Municipio union all
	select 'MG' as Estado, 'Presidente Bernardes' as Municipio union all
	select 'MG' as Estado, 'Presidente Juscelino' as Municipio union all
	select 'MG' as Estado, 'Presidente Kubitschek' as Municipio union all
	select 'MG' as Estado, 'Presidente Olegário' as Municipio union all
	select 'MG' as Estado, 'Prudente de Morais' as Municipio union all
	select 'MG' as Estado, 'Quartel Geral' as Municipio union all
	select 'MG' as Estado, 'Queluzito' as Municipio union all
	select 'MG' as Estado, 'Raposos' as Municipio union all
	select 'MG' as Estado, 'Raul Soares' as Municipio union all
	select 'MG' as Estado, 'Recreio' as Municipio union all
	select 'MG' as Estado, 'Reduto' as Municipio union all
	select 'MG' as Estado, 'Resende Costa' as Municipio union all
	select 'MG' as Estado, 'Resplendor' as Municipio union all
	select 'MG' as Estado, 'Ressaquinha' as Municipio union all
	select 'MG' as Estado, 'Riachinho' as Municipio union all
	select 'MG' as Estado, 'Riacho dos Machados' as Municipio union all
	select 'MG' as Estado, 'Ribeirão das Neves' as Municipio union all
	select 'MG' as Estado, 'Ribeirão Vermelho' as Municipio union all
	select 'MG' as Estado, 'Rio Acima' as Municipio union all
	select 'MG' as Estado, 'Rio Casca' as Municipio union all
	select 'MG' as Estado, 'Rio do Prado' as Municipio union all
	select 'MG' as Estado, 'Rio Doce' as Municipio union all
	select 'MG' as Estado, 'Rio Espera' as Municipio union all
	select 'MG' as Estado, 'Rio Manso' as Municipio union all
	select 'MG' as Estado, 'Rio Novo' as Municipio union all
	select 'MG' as Estado, 'Rio Paranaíba' as Municipio union all
	select 'MG' as Estado, 'Rio Pardo de Minas' as Municipio union all
	select 'MG' as Estado, 'Rio Piracicaba' as Municipio union all
	select 'MG' as Estado, 'Rio Pomba' as Municipio union all
	select 'MG' as Estado, 'Rio Preto' as Municipio union all
	select 'MG' as Estado, 'Rio Vermelho' as Municipio union all
	select 'MG' as Estado, 'Ritápolis' as Municipio union all
	select 'MG' as Estado, 'Rochedo de Minas' as Municipio union all
	select 'MG' as Estado, 'Rodeiro' as Municipio union all
	select 'MG' as Estado, 'Romaria' as Municipio union all
	select 'MG' as Estado, 'Rosário da Limeira' as Municipio union all
	select 'MG' as Estado, 'Rubelita' as Municipio union all
	select 'MG' as Estado, 'Rubim' as Municipio union all
	select 'MG' as Estado, 'Sabará' as Municipio union all
	select 'MG' as Estado, 'Sabinópolis' as Municipio union all
	select 'MG' as Estado, 'Sacramento' as Municipio union all
	select 'MG' as Estado, 'Salinas' as Municipio union all
	select 'MG' as Estado, 'Salto da Divisa' as Municipio union all
	select 'MG' as Estado, 'Santa Bárbara' as Municipio union all
	select 'MG' as Estado, 'Santa Bárbara do Leste' as Municipio union all
	select 'MG' as Estado, 'Santa Bárbara do Monte Verde' as Municipio union all
	select 'MG' as Estado, 'Santa Bárbara do Tugúrio' as Municipio union all
	select 'MG' as Estado, 'Santa Cruz de Minas' as Municipio union all
	select 'MG' as Estado, 'Santa Cruz de Salinas' as Municipio union all
	select 'MG' as Estado, 'Santa Cruz do Escalvado' as Municipio union all
	select 'MG' as Estado, 'Santa Efigênia de Minas' as Municipio union all
	select 'MG' as Estado, 'Santa Fé de Minas' as Municipio union all
	select 'MG' as Estado, 'Santa Helena de Minas' as Municipio union all
	select 'MG' as Estado, 'Santa Juliana' as Municipio union all
	select 'MG' as Estado, 'Santa Luzia' as Municipio union all
	select 'MG' as Estado, 'Santa Margarida' as Municipio union all
	select 'MG' as Estado, 'Santa Maria de Itabira' as Municipio union all
	select 'MG' as Estado, 'Santa Maria do Salto' as Municipio union all
	select 'MG' as Estado, 'Santa Maria do Suaçuí' as Municipio union all
	select 'MG' as Estado, 'Santa Rita de Caldas' as Municipio union all
	select 'MG' as Estado, 'Santa Rita de Ibitipoca' as Municipio union all
	select 'MG' as Estado, 'Santa Rita de Jacutinga' as Municipio union all
	select 'MG' as Estado, 'Santa Rita de Minas' as Municipio union all
	select 'MG' as Estado, 'Santa Rita do Itueto' as Municipio union all
	select 'MG' as Estado, 'Santa Rita do Sapucaí' as Municipio union all
	select 'MG' as Estado, 'Santa Rosa da Serra' as Municipio union all
	select 'MG' as Estado, 'Santa Vitória' as Municipio union all
	select 'MG' as Estado, 'Santana da Vargem' as Municipio union all
	select 'MG' as Estado, 'Santana de Cataguases' as Municipio union all
	select 'MG' as Estado, 'Santana de Pirapama' as Municipio union all
	select 'MG' as Estado, 'Santana do Deserto' as Municipio union all
	select 'MG' as Estado, 'Santana do Garambéu' as Municipio union all
	select 'MG' as Estado, 'Santana do Jacaré' as Municipio union all
	select 'MG' as Estado, 'Santana do Manhuaçu' as Municipio union all
	select 'MG' as Estado, 'Santana do Paraíso' as Municipio union all
	select 'MG' as Estado, 'Santana do Riacho' as Municipio union all
	select 'MG' as Estado, 'Santana dos Montes' as Municipio union all
	select 'MG' as Estado, 'Santo Antônio do Amparo' as Municipio union all
	select 'MG' as Estado, 'Santo Antônio do Aventureiro' as Municipio union all
	select 'MG' as Estado, 'Santo Antônio do Grama' as Municipio union all
	select 'MG' as Estado, 'Santo Antônio do Itambé' as Municipio union all
	select 'MG' as Estado, 'Santo Antônio do Jacinto' as Municipio union all
	select 'MG' as Estado, 'Santo Antônio do Monte' as Municipio union all
	select 'MG' as Estado, 'Santo Antônio do Retiro' as Municipio union all
	select 'MG' as Estado, 'Santo Antônio do Rio Abaixo' as Municipio union all
	select 'MG' as Estado, 'Santo Hipólito' as Municipio union all
	select 'MG' as Estado, 'Santos Dumont' as Municipio union all
	select 'MG' as Estado, 'São Bento Abade' as Municipio union all
	select 'MG' as Estado, 'São Brás do Suaçuí' as Municipio union all
	select 'MG' as Estado, 'São Domingos das Dores' as Municipio union all
	select 'MG' as Estado, 'São Domingos do Prata' as Municipio union all
	select 'MG' as Estado, 'São Félix de Minas' as Municipio union all
	select 'MG' as Estado, 'São Francisco' as Municipio union all
	select 'MG' as Estado, 'São Francisco de Paula' as Municipio union all
	select 'MG' as Estado, 'São Francisco de Sales' as Municipio union all
	select 'MG' as Estado, 'São Francisco do Glória' as Municipio union all
	select 'MG' as Estado, 'São Geraldo' as Municipio union all
	select 'MG' as Estado, 'São Geraldo da Piedade' as Municipio union all
	select 'MG' as Estado, 'São Geraldo do Baixio' as Municipio union all
	select 'MG' as Estado, 'São Gonçalo do Abaeté' as Municipio union all
	select 'MG' as Estado, 'São Gonçalo do Pará' as Municipio union all
	select 'MG' as Estado, 'São Gonçalo do Rio Abaixo' as Municipio union all
	select 'MG' as Estado, 'São Gonçalo do Rio Preto' as Municipio union all
	select 'MG' as Estado, 'São Gonçalo do Sapucaí' as Municipio union all
	select 'MG' as Estado, 'São Gotardo' as Municipio union all
	select 'MG' as Estado, 'São João Batista do Glória' as Municipio union all
	select 'MG' as Estado, 'São João da Lagoa' as Municipio union all
	select 'MG' as Estado, 'São João da Mata' as Municipio union all
	select 'MG' as Estado, 'São João da Ponte' as Municipio union all
	select 'MG' as Estado, 'São João das Missões' as Municipio union all
	select 'MG' as Estado, 'São João del Rei' as Municipio union all
	select 'MG' as Estado, 'São João do Manhuaçu' as Municipio union all
	select 'MG' as Estado, 'São João do Manteninha' as Municipio union all
	select 'MG' as Estado, 'São João do Oriente' as Municipio union all
	select 'MG' as Estado, 'São João do Pacuí' as Municipio union all
	select 'MG' as Estado, 'São João do Paraíso' as Municipio union all
	select 'MG' as Estado, 'São João Evangelista' as Municipio union all
	select 'MG' as Estado, 'São João Nepomuceno' as Municipio union all
	select 'MG' as Estado, 'São Joaquim de Bicas' as Municipio union all
	select 'MG' as Estado, 'São José da Barra' as Municipio union all
	select 'MG' as Estado, 'São José da Lapa' as Municipio union all
	select 'MG' as Estado, 'São José da Safira' as Municipio union all
	select 'MG' as Estado, 'São José da Varginha' as Municipio union all
	select 'MG' as Estado, 'São José do Alegre' as Municipio union all
	select 'MG' as Estado, 'São José do Divino' as Municipio union all
	select 'MG' as Estado, 'São José do Goiabal' as Municipio union all
	select 'MG' as Estado, 'São José do Jacuri' as Municipio union all
	select 'MG' as Estado, 'São José do Mantimento' as Municipio union all
	select 'MG' as Estado, 'São Lourenço' as Municipio union all
	select 'MG' as Estado, 'São Miguel do Anta' as Municipio union all
	select 'MG' as Estado, 'São Pedro da União' as Municipio union all
	select 'MG' as Estado, 'São Pedro do Suaçuí' as Municipio union all
	select 'MG' as Estado, 'São Pedro dos Ferros' as Municipio union all
	select 'MG' as Estado, 'São Romão' as Municipio union all
	select 'MG' as Estado, 'São Roque de Minas' as Municipio union all
	select 'MG' as Estado, 'São Sebastião da Bela Vista' as Municipio union all
	select 'MG' as Estado, 'São Sebastião da Vargem Alegre' as Municipio union all
	select 'MG' as Estado, 'São Sebastião do Anta' as Municipio union all
	select 'MG' as Estado, 'São Sebastião do Maranhão' as Municipio union all
	select 'MG' as Estado, 'São Sebastião do Oeste' as Municipio union all
	select 'MG' as Estado, 'São Sebastião do Paraíso' as Municipio union all
	select 'MG' as Estado, 'São Sebastião do Rio Preto' as Municipio union all
	select 'MG' as Estado, 'São Sebastião do Rio Verde' as Municipio union all
	select 'MG' as Estado, 'São Thomé das Letras' as Municipio union all
	select 'MG' as Estado, 'São Tiago' as Municipio union all
	select 'MG' as Estado, 'São Tomás de Aquino' as Municipio union all
	select 'MG' as Estado, 'São Vicente de Minas' as Municipio union all
	select 'MG' as Estado, 'Sapucaí-Mirim' as Municipio union all
	select 'MG' as Estado, 'Sardoá' as Municipio union all
	select 'MG' as Estado, 'Sarzedo' as Municipio union all
	select 'MG' as Estado, 'Sem-Peixe' as Municipio union all
	select 'MG' as Estado, 'Senador Amaral' as Municipio union all
	select 'MG' as Estado, 'Senador Cortes' as Municipio union all
	select 'MG' as Estado, 'Senador Firmino' as Municipio union all
	select 'MG' as Estado, 'Senador José Bento' as Municipio union all
	select 'MG' as Estado, 'Senador Modestino Gonçalves' as Municipio union all
	select 'MG' as Estado, 'Senhora de Oliveira' as Municipio union all
	select 'MG' as Estado, 'Senhora do Porto' as Municipio union all
	select 'MG' as Estado, 'Senhora dos Remédios' as Municipio union all
	select 'MG' as Estado, 'Sericita' as Municipio union all
	select 'MG' as Estado, 'Seritinga' as Municipio union all
	select 'MG' as Estado, 'Serra Azul de Minas' as Municipio union all
	select 'MG' as Estado, 'Serra da Saudade' as Municipio union all
	select 'MG' as Estado, 'Serra do Salitre' as Municipio union all
	select 'MG' as Estado, 'Serra dos Aimorés' as Municipio union all
	select 'MG' as Estado, 'Serrania' as Municipio union all
	select 'MG' as Estado, 'Serranópolis de Minas' as Municipio union all
	select 'MG' as Estado, 'Serranos' as Municipio union all
	select 'MG' as Estado, 'Serro' as Municipio union all
	select 'MG' as Estado, 'Sete Lagoas' as Municipio union all
	select 'MG' as Estado, 'Setubinha' as Municipio union all
	select 'MG' as Estado, 'Silveirânia' as Municipio union all
	select 'MG' as Estado, 'Silvianópolis' as Municipio union all
	select 'MG' as Estado, 'Simão Pereira' as Municipio union all
	select 'MG' as Estado, 'Simonésia' as Municipio union all
	select 'MG' as Estado, 'Sobrália' as Municipio union all
	select 'MG' as Estado, 'Soledade de Minas' as Municipio union all
	select 'MG' as Estado, 'Tabuleiro' as Municipio union all
	select 'MG' as Estado, 'Taiobeiras' as Municipio union all
	select 'MG' as Estado, 'Taparuba' as Municipio union all
	select 'MG' as Estado, 'Tapira' as Municipio union all
	select 'MG' as Estado, 'Tapiraí' as Municipio union all
	select 'MG' as Estado, 'Taquaraçu de Minas' as Municipio union all
	select 'MG' as Estado, 'Tarumirim' as Municipio union all
	select 'MG' as Estado, 'Teixeiras' as Municipio union all
	select 'MG' as Estado, 'Teófilo Otoni' as Municipio union all
	select 'MG' as Estado, 'Timóteo' as Municipio union all
	select 'MG' as Estado, 'Tiradentes' as Municipio union all
	select 'MG' as Estado, 'Tiros' as Municipio union all
	select 'MG' as Estado, 'Tocantins' as Municipio union all
	select 'MG' as Estado, 'Tocos do Moji' as Municipio union all
	select 'MG' as Estado, 'Toledo' as Municipio union all
	select 'MG' as Estado, 'Tombos' as Municipio union all
	select 'MG' as Estado, 'Três Corações' as Municipio union all
	select 'MG' as Estado, 'Três Marias' as Municipio union all
	select 'MG' as Estado, 'Três Pontas' as Municipio union all
	select 'MG' as Estado, 'Tumiritinga' as Municipio union all
	select 'MG' as Estado, 'Tupaciguara' as Municipio union all
	select 'MG' as Estado, 'Turmalina' as Municipio union all
	select 'MG' as Estado, 'Turvolândia' as Municipio union all
	select 'MG' as Estado, 'Ubá' as Municipio union all
	select 'MG' as Estado, 'Ubaí' as Municipio union all
	select 'MG' as Estado, 'Ubaporanga' as Municipio union all
	select 'MG' as Estado, 'Uberaba' as Municipio union all
	select 'MG' as Estado, 'Uberlândia' as Municipio union all
	select 'MG' as Estado, 'Umburatiba' as Municipio union all
	select 'MG' as Estado, 'Unaí' as Municipio union all
	select 'MG' as Estado, 'União de Minas' as Municipio union all
	select 'MG' as Estado, 'Uruana de Minas' as Municipio union all
	select 'MG' as Estado, 'Urucânia' as Municipio union all
	select 'MG' as Estado, 'Urucuia' as Municipio union all
	select 'MG' as Estado, 'Vargem Alegre' as Municipio union all
	select 'MG' as Estado, 'Vargem Bonita' as Municipio union all
	select 'MG' as Estado, 'Vargem Grande do Rio Pardo' as Municipio union all
	select 'MG' as Estado, 'Varginha' as Municipio union all
	select 'MG' as Estado, 'Varjão de Minas' as Municipio union all
	select 'MG' as Estado, 'Várzea da Palma' as Municipio union all
	select 'MG' as Estado, 'Varzelândia' as Municipio union all
	select 'MG' as Estado, 'Vazante' as Municipio union all
	select 'MG' as Estado, 'Verdelândia' as Municipio union all
	select 'MG' as Estado, 'Veredinha' as Municipio union all
	select 'MG' as Estado, 'Veríssimo' as Municipio union all
	select 'MG' as Estado, 'Vermelho Novo' as Municipio union all
	select 'MG' as Estado, 'Vespasiano' as Municipio union all
	select 'MG' as Estado, 'Viçosa' as Municipio union all
	select 'MG' as Estado, 'Vieiras' as Municipio union all
	select 'MG' as Estado, 'Virgem da Lapa' as Municipio union all
	select 'MG' as Estado, 'Virgínia' as Municipio union all
	select 'MG' as Estado, 'Virginópolis' as Municipio union all
	select 'MG' as Estado, 'Virgolândia' as Municipio union all
	select 'MG' as Estado, 'Visconde do Rio Branco' as Municipio union all
	select 'MG' as Estado, 'Volta Grande' as Municipio union all
	select 'MG' as Estado, 'Wenceslau Braz' as Municipio union all
	select 'ES' as Estado, 'Afonso Cláudio' as Municipio union all
	select 'ES' as Estado, 'Água Doce do Norte' as Municipio union all
	select 'ES' as Estado, 'Águia Branca' as Municipio union all
	select 'ES' as Estado, 'Alegre' as Municipio union all
	select 'ES' as Estado, 'Alfredo Chaves' as Municipio union all
	select 'ES' as Estado, 'Alto Rio Novo' as Municipio union all
	select 'ES' as Estado, 'Anchieta' as Municipio union all
	select 'ES' as Estado, 'Apiacá' as Municipio union all
	select 'ES' as Estado, 'Aracruz' as Municipio union all
	select 'ES' as Estado, 'Atilio Vivacqua' as Municipio union all
	select 'ES' as Estado, 'Baixo Guandu' as Municipio union all
	select 'ES' as Estado, 'Barra de São Francisco' as Municipio union all
	select 'ES' as Estado, 'Boa Esperança' as Municipio union all
	select 'ES' as Estado, 'Bom Jesus do Norte' as Municipio union all
	select 'ES' as Estado, 'Brejetuba' as Municipio union all
	select 'ES' as Estado, 'Cachoeiro de Itapemirim' as Municipio union all
	select 'ES' as Estado, 'Cariacica' as Municipio union all
	select 'ES' as Estado, 'Castelo' as Municipio union all
	select 'ES' as Estado, 'Colatina' as Municipio union all
	select 'ES' as Estado, 'Conceição da Barra' as Municipio union all
	select 'ES' as Estado, 'Conceição do Castelo' as Municipio union all
	select 'ES' as Estado, 'Divino de São Lourenço' as Municipio union all
	select 'ES' as Estado, 'Domingos Martins' as Municipio union all
	select 'ES' as Estado, 'Dores do Rio Preto' as Municipio union all
	select 'ES' as Estado, 'Ecoporanga' as Municipio union all
	select 'ES' as Estado, 'Fundão' as Municipio union all
	select 'ES' as Estado, 'Governador Lindenberg' as Municipio union all
	select 'ES' as Estado, 'Guaçuí' as Municipio union all
	select 'ES' as Estado, 'Guarapari' as Municipio union all
	select 'ES' as Estado, 'Ibatiba' as Municipio union all
	select 'ES' as Estado, 'Ibiraçu' as Municipio union all
	select 'ES' as Estado, 'Ibitirama' as Municipio union all
	select 'ES' as Estado, 'Iconha' as Municipio union all
	select 'ES' as Estado, 'Irupi' as Municipio union all
	select 'ES' as Estado, 'Itaguaçu' as Municipio union all
	select 'ES' as Estado, 'Itapemirim' as Municipio union all
	select 'ES' as Estado, 'Itarana' as Municipio union all
	select 'ES' as Estado, 'Iúna' as Municipio union all
	select 'ES' as Estado, 'Jaguaré' as Municipio union all
	select 'ES' as Estado, 'Jerônimo Monteiro' as Municipio union all
	select 'ES' as Estado, 'João Neiva' as Municipio union all
	select 'ES' as Estado, 'Laranja da Terra' as Municipio union all
	select 'ES' as Estado, 'Linhares' as Municipio union all
	select 'ES' as Estado, 'Mantenópolis' as Municipio union all
	select 'ES' as Estado, 'Marataízes' as Municipio union all
	select 'ES' as Estado, 'Marechal Floriano' as Municipio union all
	select 'ES' as Estado, 'Marilândia' as Municipio union all
	select 'ES' as Estado, 'Mimoso do Sul' as Municipio union all
	select 'ES' as Estado, 'Montanha' as Municipio union all
	select 'ES' as Estado, 'Mucurici' as Municipio union all
	select 'ES' as Estado, 'Muniz Freire' as Municipio union all
	select 'ES' as Estado, 'Muqui' as Municipio union all
	select 'ES' as Estado, 'Nova Venécia' as Municipio union all
	select 'ES' as Estado, 'Pancas' as Municipio union all
	select 'ES' as Estado, 'Pedro Canário' as Municipio union all
	select 'ES' as Estado, 'Pinheiros' as Municipio union all
	select 'ES' as Estado, 'Piúma' as Municipio union all
	select 'ES' as Estado, 'Ponto Belo' as Municipio union all
	select 'ES' as Estado, 'Presidente Kennedy' as Municipio union all
	select 'ES' as Estado, 'Rio Bananal' as Municipio union all
	select 'ES' as Estado, 'Rio Novo do Sul' as Municipio union all
	select 'ES' as Estado, 'Santa Leopoldina' as Municipio union all
	select 'ES' as Estado, 'Santa Maria de Jetibá' as Municipio union all
	select 'ES' as Estado, 'Santa Teresa' as Municipio union all
	select 'ES' as Estado, 'São Domingos do Norte' as Municipio union all
	select 'ES' as Estado, 'São Gabriel da Palha' as Municipio union all
	select 'ES' as Estado, 'São José do Calçado' as Municipio union all
	select 'ES' as Estado, 'São Mateus' as Municipio union all
	select 'ES' as Estado, 'São Roque do Canaã' as Municipio union all
	select 'ES' as Estado, 'Serra' as Municipio union all
	select 'ES' as Estado, 'Sooretama' as Municipio union all
	select 'ES' as Estado, 'Vargem Alta' as Municipio union all
	select 'ES' as Estado, 'Venda Nova do Imigrante' as Municipio union all
	select 'ES' as Estado, 'Viana' as Municipio union all
	select 'ES' as Estado, 'Vila Pavão' as Municipio union all
	select 'ES' as Estado, 'Vila Valério' as Municipio union all
	select 'ES' as Estado, 'Vila Velha' as Municipio union all
	select 'ES' as Estado, 'Vitória' as Municipio union all
	select 'RJ' as Estado, 'Angra dos Reis' as Municipio union all
	select 'RJ' as Estado, 'Aperibé' as Municipio union all
	select 'RJ' as Estado, 'Araruama' as Municipio union all
	select 'RJ' as Estado, 'Areal' as Municipio union all
	select 'RJ' as Estado, 'Armação dos Búzios' as Municipio union all
	select 'RJ' as Estado, 'Arraial do Cabo' as Municipio union all
	select 'RJ' as Estado, 'Barra do Piraí' as Municipio union all
	select 'RJ' as Estado, 'Barra Mansa' as Municipio union all
	select 'RJ' as Estado, 'Belford Roxo' as Municipio union all
	select 'RJ' as Estado, 'Bom Jardim' as Municipio union all
	select 'RJ' as Estado, 'Bom Jesus do Itabapoana' as Municipio union all
	select 'RJ' as Estado, 'Cabo Frio' as Municipio union all
	select 'RJ' as Estado, 'Cachoeiras de Macacu' as Municipio union all
	select 'RJ' as Estado, 'Cambuci' as Municipio union all
	select 'RJ' as Estado, 'Campos dos Goytacazes' as Municipio union all
	select 'RJ' as Estado, 'Cantagalo' as Municipio union all
	select 'RJ' as Estado, 'Carapebus' as Municipio union all
	select 'RJ' as Estado, 'Cardoso Moreira' as Municipio union all
	select 'RJ' as Estado, 'Carmo' as Municipio union all
	select 'RJ' as Estado, 'Casimiro de Abreu' as Municipio union all
	select 'RJ' as Estado, 'Comendador Levy Gasparian' as Municipio union all
	select 'RJ' as Estado, 'Conceição de Macabu' as Municipio union all
	select 'RJ' as Estado, 'Cordeiro' as Municipio union all
	select 'RJ' as Estado, 'Duas Barras' as Municipio union all
	select 'RJ' as Estado, 'Duque de Caxias' as Municipio union all
	select 'RJ' as Estado, 'Engenheiro Paulo de Frontin' as Municipio union all
	select 'RJ' as Estado, 'Guapimirim' as Municipio union all
	select 'RJ' as Estado, 'Iguaba Grande' as Municipio union all
	select 'RJ' as Estado, 'Itaboraí' as Municipio union all
	select 'RJ' as Estado, 'Itaguaí' as Municipio union all
	select 'RJ' as Estado, 'Italva' as Municipio union all
	select 'RJ' as Estado, 'Itaocara' as Municipio union all
	select 'RJ' as Estado, 'Itaperuna' as Municipio union all
	select 'RJ' as Estado, 'Itatiaia' as Municipio union all
	select 'RJ' as Estado, 'Japeri' as Municipio union all
	select 'RJ' as Estado, 'Laje do Muriaé' as Municipio union all
	select 'RJ' as Estado, 'Macaé' as Municipio union all
	select 'RJ' as Estado, 'Macuco' as Municipio union all
	select 'RJ' as Estado, 'Magé' as Municipio union all
	select 'RJ' as Estado, 'Mangaratiba' as Municipio union all
	select 'RJ' as Estado, 'Maricá' as Municipio union all
	select 'RJ' as Estado, 'Mendes' as Municipio union all
	select 'RJ' as Estado, 'Mesquita' as Municipio union all
	select 'RJ' as Estado, 'Miguel Pereira' as Municipio union all
	select 'RJ' as Estado, 'Miracema' as Municipio union all
	select 'RJ' as Estado, 'Natividade' as Municipio union all
	select 'RJ' as Estado, 'Nilópolis' as Municipio union all
	select 'RJ' as Estado, 'Niterói' as Municipio union all
	select 'RJ' as Estado, 'Nova Friburgo' as Municipio union all
	select 'RJ' as Estado, 'Nova Iguaçu' as Municipio union all
	select 'RJ' as Estado, 'Paracambi' as Municipio union all
	select 'RJ' as Estado, 'Paraíba do Sul' as Municipio union all
	select 'RJ' as Estado, 'Parati' as Municipio union all
	select 'RJ' as Estado, 'Paty do Alferes' as Municipio union all
	select 'RJ' as Estado, 'Petrópolis' as Municipio union all
	select 'RJ' as Estado, 'Pinheiral' as Municipio union all
	select 'RJ' as Estado, 'Piraí' as Municipio union all
	select 'RJ' as Estado, 'Porciúncula' as Municipio union all
	select 'RJ' as Estado, 'Porto Real' as Municipio union all
	select 'RJ' as Estado, 'Quatis' as Municipio union all
	select 'RJ' as Estado, 'Queimados' as Municipio union all
	select 'RJ' as Estado, 'Quissamã' as Municipio union all
	select 'RJ' as Estado, 'Resende' as Municipio union all
	select 'RJ' as Estado, 'Rio Bonito' as Municipio union all
	select 'RJ' as Estado, 'Rio Claro' as Municipio union all
	select 'RJ' as Estado, 'Rio das Flores' as Municipio union all
	select 'RJ' as Estado, 'Rio das Ostras' as Municipio union all
	select 'RJ' as Estado, 'Rio de Janeiro' as Municipio union all
	select 'RJ' as Estado, 'Santa Maria Madalena' as Municipio union all
	select 'RJ' as Estado, 'Santo Antônio de Pádua' as Municipio union all
	select 'RJ' as Estado, 'São Fidélis' as Municipio union all
	select 'RJ' as Estado, 'São Francisco de Itabapoana' as Municipio union all
	select 'RJ' as Estado, 'São Gonçalo' as Municipio union all
	select 'RJ' as Estado, 'São João da Barra' as Municipio union all
	select 'RJ' as Estado, 'São João de Meriti' as Municipio union all
	select 'RJ' as Estado, 'São José de Ubá' as Municipio union all
	select 'RJ' as Estado, 'São José do Vale do Rio Preto' as Municipio union all
	select 'RJ' as Estado, 'São Pedro da Aldeia' as Municipio union all
	select 'RJ' as Estado, 'São Sebastião do Alto' as Municipio union all
	select 'RJ' as Estado, 'Sapucaia' as Municipio union all
	select 'RJ' as Estado, 'Saquarema' as Municipio union all
	select 'RJ' as Estado, 'Seropédica' as Municipio union all
	select 'RJ' as Estado, 'Silva Jardim' as Municipio union all
	select 'RJ' as Estado, 'Sumidouro' as Municipio union all
	select 'RJ' as Estado, 'Tanguá' as Municipio union all
	select 'RJ' as Estado, 'Teresópolis' as Municipio union all
	select 'RJ' as Estado, 'Trajano de Morais' as Municipio union all
	select 'RJ' as Estado, 'Três Rios' as Municipio union all
	select 'RJ' as Estado, 'Valença' as Municipio union all
	select 'RJ' as Estado, 'Varre-Sai' as Municipio union all
	select 'RJ' as Estado, 'Vassouras' as Municipio union all
	select 'RJ' as Estado, 'Volta Redonda' as Municipio union all
	select 'SP' as Estado, 'Adamantina' as Municipio union all
	select 'SP' as Estado, 'Adolfo' as Municipio union all
	select 'SP' as Estado, 'Aguaí' as Municipio union all
	select 'SP' as Estado, 'Águas da Prata' as Municipio union all
	select 'SP' as Estado, 'Águas de Lindóia' as Municipio union all
	select 'SP' as Estado, 'Águas de Santa Bárbara' as Municipio union all
	select 'SP' as Estado, 'Águas de São Pedro' as Municipio union all
	select 'SP' as Estado, 'Agudos' as Municipio union all
	select 'SP' as Estado, 'Alambari' as Municipio union all
	select 'SP' as Estado, 'Alfredo Marcondes' as Municipio union all
	select 'SP' as Estado, 'Altair' as Municipio union all
	select 'SP' as Estado, 'Altinópolis' as Municipio union all
	select 'SP' as Estado, 'Alto Alegre' as Municipio union all
	select 'SP' as Estado, 'Alumínio' as Municipio union all
	select 'SP' as Estado, 'Álvares Florence' as Municipio union all
	select 'SP' as Estado, 'Álvares Machado' as Municipio union all
	select 'SP' as Estado, 'Álvaro de Carvalho' as Municipio union all
	select 'SP' as Estado, 'Alvinlândia' as Municipio union all
	select 'SP' as Estado, 'Americana' as Municipio union all
	select 'SP' as Estado, 'Américo Brasiliense' as Municipio union all
	select 'SP' as Estado, 'Américo de Campos' as Municipio union all
	select 'SP' as Estado, 'Amparo' as Municipio union all
	select 'SP' as Estado, 'Analândia' as Municipio union all
	select 'SP' as Estado, 'Andradina' as Municipio union all
	select 'SP' as Estado, 'Angatuba' as Municipio union all
	select 'SP' as Estado, 'Anhembi' as Municipio union all
	select 'SP' as Estado, 'Anhumas' as Municipio union all
	select 'SP' as Estado, 'Aparecida' as Municipio union all
	select 'SP' as Estado, 'Aparecida d''Oeste' as Municipio union all
	select 'SP' as Estado, 'Apiaí' as Municipio union all
	select 'SP' as Estado, 'Araçariguama' as Municipio union all
	select 'SP' as Estado, 'Araçatuba' as Municipio union all
	select 'SP' as Estado, 'Araçoiaba da Serra' as Municipio union all
	select 'SP' as Estado, 'Aramina' as Municipio union all
	select 'SP' as Estado, 'Arandu' as Municipio union all
	select 'SP' as Estado, 'Arapeí' as Municipio union all
	select 'SP' as Estado, 'Araraquara' as Municipio union all
	select 'SP' as Estado, 'Araras' as Municipio union all
	select 'SP' as Estado, 'Arco-Íris' as Municipio union all
	select 'SP' as Estado, 'Arealva' as Municipio union all
	select 'SP' as Estado, 'Areias' as Municipio union all
	select 'SP' as Estado, 'Areiópolis' as Municipio union all
	select 'SP' as Estado, 'Ariranha' as Municipio union all
	select 'SP' as Estado, 'Artur Nogueira' as Municipio union all
	select 'SP' as Estado, 'Arujá' as Municipio union all
	select 'SP' as Estado, 'Aspásia' as Municipio union all
	select 'SP' as Estado, 'Assis' as Municipio union all
	select 'SP' as Estado, 'Atibaia' as Municipio union all
	select 'SP' as Estado, 'Auriflama' as Municipio union all
	select 'SP' as Estado, 'Avaí' as Municipio union all
	select 'SP' as Estado, 'Avanhandava' as Municipio union all
	select 'SP' as Estado, 'Avaré' as Municipio union all
	select 'SP' as Estado, 'Bady Bassitt' as Municipio union all
	select 'SP' as Estado, 'Balbinos' as Municipio union all
	select 'SP' as Estado, 'Bálsamo' as Municipio union all
	select 'SP' as Estado, 'Bananal' as Municipio union all
	select 'SP' as Estado, 'Barão de Antonina' as Municipio union all
	select 'SP' as Estado, 'Barbosa' as Municipio union all
	select 'SP' as Estado, 'Bariri' as Municipio union all
	select 'SP' as Estado, 'Barra Bonita' as Municipio union all
	select 'SP' as Estado, 'Barra do Chapéu' as Municipio union all
	select 'SP' as Estado, 'Barra do Turvo' as Municipio union all
	select 'SP' as Estado, 'Barretos' as Municipio union all
	select 'SP' as Estado, 'Barrinha' as Municipio union all
	select 'SP' as Estado, 'Barueri' as Municipio union all
	select 'SP' as Estado, 'Bastos' as Municipio union all
	select 'SP' as Estado, 'Batatais' as Municipio union all
	select 'SP' as Estado, 'Bauru' as Municipio union all
	select 'SP' as Estado, 'Bebedouro' as Municipio union all
	select 'SP' as Estado, 'Bento de Abreu' as Municipio union all
	select 'SP' as Estado, 'Bernardino de Campos' as Municipio union all
	select 'SP' as Estado, 'Bertioga' as Municipio union all
	select 'SP' as Estado, 'Bilac' as Municipio union all
	select 'SP' as Estado, 'Birigui' as Municipio union all
	select 'SP' as Estado, 'Biritiba-Mirim' as Municipio union all
	select 'SP' as Estado, 'Boa Esperança do Sul' as Municipio union all
	select 'SP' as Estado, 'Bocaina' as Municipio union all
	select 'SP' as Estado, 'Bofete' as Municipio union all
	select 'SP' as Estado, 'Boituva' as Municipio union all
	select 'SP' as Estado, 'Bom Jesus dos Perdões' as Municipio union all
	select 'SP' as Estado, 'Bom Sucesso de Itararé' as Municipio union all
	select 'SP' as Estado, 'Borá' as Municipio union all
	select 'SP' as Estado, 'Boracéia' as Municipio union all
	select 'SP' as Estado, 'Borborema' as Municipio union all
	select 'SP' as Estado, 'Borebi' as Municipio union all
	select 'SP' as Estado, 'Botucatu' as Municipio union all
	select 'SP' as Estado, 'Bragança Paulista' as Municipio union all
	select 'SP' as Estado, 'Braúna' as Municipio union all
	select 'SP' as Estado, 'Brejo Alegre' as Municipio union all
	select 'SP' as Estado, 'Brodowski' as Municipio union all
	select 'SP' as Estado, 'Brotas' as Municipio union all
	select 'SP' as Estado, 'Buri' as Municipio union all
	select 'SP' as Estado, 'Buritama' as Municipio union all
	select 'SP' as Estado, 'Buritizal' as Municipio union all
	select 'SP' as Estado, 'Cabrália Paulista' as Municipio union all
	select 'SP' as Estado, 'Cabreúva' as Municipio union all
	select 'SP' as Estado, 'Caçapava' as Municipio union all
	select 'SP' as Estado, 'Cachoeira Paulista' as Municipio union all
	select 'SP' as Estado, 'Caconde' as Municipio union all
	select 'SP' as Estado, 'Cafelândia' as Municipio union all
	select 'SP' as Estado, 'Caiabu' as Municipio union all
	select 'SP' as Estado, 'Caieiras' as Municipio union all
	select 'SP' as Estado, 'Caiuá' as Municipio union all
	select 'SP' as Estado, 'Cajamar' as Municipio union all
	select 'SP' as Estado, 'Cajati' as Municipio union all
	select 'SP' as Estado, 'Cajobi' as Municipio union all
	select 'SP' as Estado, 'Cajuru' as Municipio union all
	select 'SP' as Estado, 'Campina do Monte Alegre' as Municipio union all
	select 'SP' as Estado, 'Campinas' as Municipio union all
	select 'SP' as Estado, 'Campo Limpo Paulista' as Municipio union all
	select 'SP' as Estado, 'Campos do Jordão' as Municipio union all
	select 'SP' as Estado, 'Campos Novos Paulista' as Municipio union all
	select 'SP' as Estado, 'Cananéia' as Municipio union all
	select 'SP' as Estado, 'Canas' as Municipio union all
	select 'SP' as Estado, 'Cândido Mota' as Municipio union all
	select 'SP' as Estado, 'Cândido Rodrigues' as Municipio union all
	select 'SP' as Estado, 'Canitar' as Municipio union all
	select 'SP' as Estado, 'Capão Bonito' as Municipio union all
	select 'SP' as Estado, 'Capela do Alto' as Municipio union all
	select 'SP' as Estado, 'Capivari' as Municipio union all
	select 'SP' as Estado, 'Caraguatatuba' as Municipio union all
	select 'SP' as Estado, 'Carapicuíba' as Municipio union all
	select 'SP' as Estado, 'Cardoso' as Municipio union all
	select 'SP' as Estado, 'Casa Branca' as Municipio union all
	select 'SP' as Estado, 'Cássia dos Coqueiros' as Municipio union all
	select 'SP' as Estado, 'Castilho' as Municipio union all
	select 'SP' as Estado, 'Catanduva' as Municipio union all
	select 'SP' as Estado, 'Catiguá' as Municipio union all
	select 'SP' as Estado, 'Cedral' as Municipio union all
	select 'SP' as Estado, 'Cerqueira César' as Municipio union all
	select 'SP' as Estado, 'Cerquilho' as Municipio union all
	select 'SP' as Estado, 'Cesário Lange' as Municipio union all
	select 'SP' as Estado, 'Charqueada' as Municipio union all
	select 'SP' as Estado, 'Chavantes' as Municipio union all
	select 'SP' as Estado, 'Clementina' as Municipio union all
	select 'SP' as Estado, 'Colina' as Municipio union all
	select 'SP' as Estado, 'Colômbia' as Municipio union all
	select 'SP' as Estado, 'Conchal' as Municipio union all
	select 'SP' as Estado, 'Conchas' as Municipio union all
	select 'SP' as Estado, 'Cordeirópolis' as Municipio union all
	select 'SP' as Estado, 'Coroados' as Municipio union all
	select 'SP' as Estado, 'Coronel Macedo' as Municipio union all
	select 'SP' as Estado, 'Corumbataí' as Municipio union all
	select 'SP' as Estado, 'Cosmópolis' as Municipio union all
	select 'SP' as Estado, 'Cosmorama' as Municipio union all
	select 'SP' as Estado, 'Cotia' as Municipio union all
	select 'SP' as Estado, 'Cravinhos' as Municipio union all
	select 'SP' as Estado, 'Cristais Paulista' as Municipio union all
	select 'SP' as Estado, 'Cruzália' as Municipio union all
	select 'SP' as Estado, 'Cruzeiro' as Municipio union all
	select 'SP' as Estado, 'Cubatão' as Municipio union all
	select 'SP' as Estado, 'Cunha' as Municipio union all
	select 'SP' as Estado, 'Descalvado' as Municipio union all
	select 'SP' as Estado, 'Diadema' as Municipio union all
	select 'SP' as Estado, 'Dirce Reis' as Municipio union all
	select 'SP' as Estado, 'Divinolândia' as Municipio union all
	select 'SP' as Estado, 'Dobrada' as Municipio union all
	select 'SP' as Estado, 'Dois Córregos' as Municipio union all
	select 'SP' as Estado, 'Dolcinópolis' as Municipio union all
	select 'SP' as Estado, 'Dourado' as Municipio union all
	select 'SP' as Estado, 'Dracena' as Municipio union all
	select 'SP' as Estado, 'Duartina' as Municipio union all
	select 'SP' as Estado, 'Dumont' as Municipio union all
	select 'SP' as Estado, 'Echaporã' as Municipio union all
	select 'SP' as Estado, 'Eldorado' as Municipio union all
	select 'SP' as Estado, 'Elias Fausto' as Municipio union all
	select 'SP' as Estado, 'Elisiário' as Municipio union all
	select 'SP' as Estado, 'Embaúba' as Municipio union all
	select 'SP' as Estado, 'Embu' as Municipio union all
	select 'SP' as Estado, 'Embu-Guaçu' as Municipio union all
	select 'SP' as Estado, 'Emilianópolis' as Municipio union all
	select 'SP' as Estado, 'Engenheiro Coelho' as Municipio union all
	select 'SP' as Estado, 'Espírito Santo do Pinhal' as Municipio union all
	select 'SP' as Estado, 'Espírito Santo do Turvo' as Municipio union all
	select 'SP' as Estado, 'Estiva Gerbi' as Municipio union all
	select 'SP' as Estado, 'Estrela do Norte' as Municipio union all
	select 'SP' as Estado, 'Estrela d''Oeste' as Municipio union all
	select 'SP' as Estado, 'Euclides da Cunha Paulista' as Municipio union all
	select 'SP' as Estado, 'Fartura' as Municipio union all
	select 'SP' as Estado, 'Fernando Prestes' as Municipio union all
	select 'SP' as Estado, 'Fernandópolis' as Municipio union all
	select 'SP' as Estado, 'Fernão' as Municipio union all
	select 'SP' as Estado, 'Ferraz de Vasconcelos' as Municipio union all
	select 'SP' as Estado, 'Flora Rica' as Municipio union all
	select 'SP' as Estado, 'Floreal' as Municipio union all
	select 'SP' as Estado, 'Flórida Paulista' as Municipio union all
	select 'SP' as Estado, 'Florínia' as Municipio union all
	select 'SP' as Estado, 'Franca' as Municipio union all
	select 'SP' as Estado, 'Francisco Morato' as Municipio union all
	select 'SP' as Estado, 'Franco da Rocha' as Municipio union all
	select 'SP' as Estado, 'Gabriel Monteiro' as Municipio union all
	select 'SP' as Estado, 'Gália' as Municipio union all
	select 'SP' as Estado, 'Garça' as Municipio union all
	select 'SP' as Estado, 'Gastão Vidigal' as Municipio union all
	select 'SP' as Estado, 'Gavião Peixoto' as Municipio union all
	select 'SP' as Estado, 'General Salgado' as Municipio union all
	select 'SP' as Estado, 'Getulina' as Municipio union all
	select 'SP' as Estado, 'Glicério' as Municipio union all
	select 'SP' as Estado, 'Guaiçara' as Municipio union all
	select 'SP' as Estado, 'Guaimbê' as Municipio union all
	select 'SP' as Estado, 'Guaíra' as Municipio union all
	select 'SP' as Estado, 'Guapiaçu' as Municipio union all
	select 'SP' as Estado, 'Guapiara' as Municipio union all
	select 'SP' as Estado, 'Guará' as Municipio union all
	select 'SP' as Estado, 'Guaraçaí' as Municipio union all
	select 'SP' as Estado, 'Guaraci' as Municipio union all
	select 'SP' as Estado, 'Guarani d''Oeste' as Municipio union all
	select 'SP' as Estado, 'Guarantã' as Municipio union all
	select 'SP' as Estado, 'Guararapes' as Municipio union all
	select 'SP' as Estado, 'Guararema' as Municipio union all
	select 'SP' as Estado, 'Guaratinguetá' as Municipio union all
	select 'SP' as Estado, 'Guareí' as Municipio union all
	select 'SP' as Estado, 'Guariba' as Municipio union all
	select 'SP' as Estado, 'Guarujá' as Municipio union all
	select 'SP' as Estado, 'Guarulhos' as Municipio union all
	select 'SP' as Estado, 'Guatapará' as Municipio union all
	select 'SP' as Estado, 'Guzolândia' as Municipio union all
	select 'SP' as Estado, 'Herculândia' as Municipio union all
	select 'SP' as Estado, 'Holambra' as Municipio union all
	select 'SP' as Estado, 'Hortolândia' as Municipio union all
	select 'SP' as Estado, 'Iacanga' as Municipio union all
	select 'SP' as Estado, 'Iacri' as Municipio union all
	select 'SP' as Estado, 'Iaras' as Municipio union all
	select 'SP' as Estado, 'Ibaté' as Municipio union all
	select 'SP' as Estado, 'Ibirá' as Municipio union all
	select 'SP' as Estado, 'Ibirarema' as Municipio union all
	select 'SP' as Estado, 'Ibitinga' as Municipio union all
	select 'SP' as Estado, 'Ibiúna' as Municipio union all
	select 'SP' as Estado, 'Icém' as Municipio union all
	select 'SP' as Estado, 'Iepê' as Municipio union all
	select 'SP' as Estado, 'Igaraçu do Tietê' as Municipio union all
	select 'SP' as Estado, 'Igarapava' as Municipio union all
	select 'SP' as Estado, 'Igaratá' as Municipio union all
	select 'SP' as Estado, 'Iguape' as Municipio union all
	select 'SP' as Estado, 'Ilha Comprida' as Municipio union all
	select 'SP' as Estado, 'Ilha Solteira' as Municipio union all
	select 'SP' as Estado, 'Ilhabela' as Municipio union all
	select 'SP' as Estado, 'Indaiatuba' as Municipio union all
	select 'SP' as Estado, 'Indiana' as Municipio union all
	select 'SP' as Estado, 'Indiaporã' as Municipio union all
	select 'SP' as Estado, 'Inúbia Paulista' as Municipio union all
	select 'SP' as Estado, 'Ipaussu' as Municipio union all
	select 'SP' as Estado, 'Iperó' as Municipio union all
	select 'SP' as Estado, 'Ipeúna' as Municipio union all
	select 'SP' as Estado, 'Ipiguá' as Municipio union all
	select 'SP' as Estado, 'Iporanga' as Municipio union all
	select 'SP' as Estado, 'Ipuã' as Municipio union all
	select 'SP' as Estado, 'Iracemápolis' as Municipio union all
	select 'SP' as Estado, 'Irapuã' as Municipio union all
	select 'SP' as Estado, 'Irapuru' as Municipio union all
	select 'SP' as Estado, 'Itaberá' as Municipio union all
	select 'SP' as Estado, 'Itaí' as Municipio union all
	select 'SP' as Estado, 'Itajobi' as Municipio union all
	select 'SP' as Estado, 'Itaju' as Municipio union all
	select 'SP' as Estado, 'Itanhaém' as Municipio union all
	select 'SP' as Estado, 'Itaóca' as Municipio union all
	select 'SP' as Estado, 'Itapecerica da Serra' as Municipio union all
	select 'SP' as Estado, 'Itapetininga' as Municipio union all
	select 'SP' as Estado, 'Itapeva' as Municipio union all
	select 'SP' as Estado, 'Itapevi' as Municipio union all
	select 'SP' as Estado, 'Itapira' as Municipio union all
	select 'SP' as Estado, 'Itapirapuã Paulista' as Municipio union all
	select 'SP' as Estado, 'Itápolis' as Municipio union all
	select 'SP' as Estado, 'Itaporanga' as Municipio union all
	select 'SP' as Estado, 'Itapuí' as Municipio union all
	select 'SP' as Estado, 'Itapura' as Municipio union all
	select 'SP' as Estado, 'Itaquaquecetuba' as Municipio union all
	select 'SP' as Estado, 'Itararé' as Municipio union all
	select 'SP' as Estado, 'Itariri' as Municipio union all
	select 'SP' as Estado, 'Itatiba' as Municipio union all
	select 'SP' as Estado, 'Itatinga' as Municipio union all
	select 'SP' as Estado, 'Itirapina' as Municipio union all
	select 'SP' as Estado, 'Itirapuã' as Municipio union all
	select 'SP' as Estado, 'Itobi' as Municipio union all
	select 'SP' as Estado, 'Itu' as Municipio union all
	select 'SP' as Estado, 'Itupeva' as Municipio union all
	select 'SP' as Estado, 'Ituverava' as Municipio union all
	select 'SP' as Estado, 'Jaborandi' as Municipio union all
	select 'SP' as Estado, 'Jaboticabal' as Municipio union all
	select 'SP' as Estado, 'Jacareí' as Municipio union all
	select 'SP' as Estado, 'Jaci' as Municipio union all
	select 'SP' as Estado, 'Jacupiranga' as Municipio union all
	select 'SP' as Estado, 'Jaguariúna' as Municipio union all
	select 'SP' as Estado, 'Jales' as Municipio union all
	select 'SP' as Estado, 'Jambeiro' as Municipio union all
	select 'SP' as Estado, 'Jandira' as Municipio union all
	select 'SP' as Estado, 'Jardinópolis' as Municipio union all
	select 'SP' as Estado, 'Jarinu' as Municipio union all
	select 'SP' as Estado, 'Jaú' as Municipio union all
	select 'SP' as Estado, 'Jeriquara' as Municipio union all
	select 'SP' as Estado, 'Joanópolis' as Municipio union all
	select 'SP' as Estado, 'João Ramalho' as Municipio union all
	select 'SP' as Estado, 'José Bonifácio' as Municipio union all
	select 'SP' as Estado, 'Júlio Mesquita' as Municipio union all
	select 'SP' as Estado, 'Jumirim' as Municipio union all
	select 'SP' as Estado, 'Jundiaí' as Municipio union all
	select 'SP' as Estado, 'Junqueirópolis' as Municipio union all
	select 'SP' as Estado, 'Juquiá' as Municipio union all
	select 'SP' as Estado, 'Juquitiba' as Municipio union all
	select 'SP' as Estado, 'Lagoinha' as Municipio union all
	select 'SP' as Estado, 'Laranjal Paulista' as Municipio union all
	select 'SP' as Estado, 'Lavínia' as Municipio union all
	select 'SP' as Estado, 'Lavrinhas' as Municipio union all
	select 'SP' as Estado, 'Leme' as Municipio union all
	select 'SP' as Estado, 'Lençóis Paulista' as Municipio union all
	select 'SP' as Estado, 'Limeira' as Municipio union all
	select 'SP' as Estado, 'Lindóia' as Municipio union all
	select 'SP' as Estado, 'Lins' as Municipio union all
	select 'SP' as Estado, 'Lorena' as Municipio union all
	select 'SP' as Estado, 'Lourdes' as Municipio union all
	select 'SP' as Estado, 'Louveira' as Municipio union all
	select 'SP' as Estado, 'Lucélia' as Municipio union all
	select 'SP' as Estado, 'Lucianópolis' as Municipio union all
	select 'SP' as Estado, 'Luís Antônio' as Municipio union all
	select 'SP' as Estado, 'Luiziânia' as Municipio union all
	select 'SP' as Estado, 'Lupércio' as Municipio union all
	select 'SP' as Estado, 'Lutécia' as Municipio union all
	select 'SP' as Estado, 'Macatuba' as Municipio union all
	select 'SP' as Estado, 'Macaubal' as Municipio union all
	select 'SP' as Estado, 'Macedônia' as Municipio union all
	select 'SP' as Estado, 'Magda' as Municipio union all
	select 'SP' as Estado, 'Mairinque' as Municipio union all
	select 'SP' as Estado, 'Mairiporã' as Municipio union all
	select 'SP' as Estado, 'Manduri' as Municipio union all
	select 'SP' as Estado, 'Marabá Paulista' as Municipio union all
	select 'SP' as Estado, 'Maracaí' as Municipio union all
	select 'SP' as Estado, 'Marapoama' as Municipio union all
	select 'SP' as Estado, 'Mariápolis' as Municipio union all
	select 'SP' as Estado, 'Marília' as Municipio union all
	select 'SP' as Estado, 'Marinópolis' as Municipio union all
	select 'SP' as Estado, 'Martinópolis' as Municipio union all
	select 'SP' as Estado, 'Matão' as Municipio union all
	select 'SP' as Estado, 'Mauá' as Municipio union all
	select 'SP' as Estado, 'Mendonça' as Municipio union all
	select 'SP' as Estado, 'Meridiano' as Municipio union all
	select 'SP' as Estado, 'Mesópolis' as Municipio union all
	select 'SP' as Estado, 'Miguelópolis' as Municipio union all
	select 'SP' as Estado, 'Mineiros do Tietê' as Municipio union all
	select 'SP' as Estado, 'Mira Estrela' as Municipio union all
	select 'SP' as Estado, 'Miracatu' as Municipio union all
	select 'SP' as Estado, 'Mirandópolis' as Municipio union all
	select 'SP' as Estado, 'Mirante do Paranapanema' as Municipio union all
	select 'SP' as Estado, 'Mirassol' as Municipio union all
	select 'SP' as Estado, 'Mirassolândia' as Municipio union all
	select 'SP' as Estado, 'Mococa' as Municipio union all
	select 'SP' as Estado, 'Mogi das Cruzes' as Municipio union all
	select 'SP' as Estado, 'Mogi Guaçu' as Municipio union all
	select 'SP' as Estado, 'Moji Mirim' as Municipio union all
	select 'SP' as Estado, 'Mombuca' as Municipio union all
	select 'SP' as Estado, 'Monções' as Municipio union all
	select 'SP' as Estado, 'Mongaguá' as Municipio union all
	select 'SP' as Estado, 'Monte Alegre do Sul' as Municipio union all
	select 'SP' as Estado, 'Monte Alto' as Municipio union all
	select 'SP' as Estado, 'Monte Aprazível' as Municipio union all
	select 'SP' as Estado, 'Monte Azul Paulista' as Municipio union all
	select 'SP' as Estado, 'Monte Castelo' as Municipio union all
	select 'SP' as Estado, 'Monte Mor' as Municipio union all
	select 'SP' as Estado, 'Monteiro Lobato' as Municipio union all
	select 'SP' as Estado, 'Morro Agudo' as Municipio union all
	select 'SP' as Estado, 'Morungaba' as Municipio union all
	select 'SP' as Estado, 'Motuca' as Municipio union all
	select 'SP' as Estado, 'Murutinga do Sul' as Municipio union all
	select 'SP' as Estado, 'Nantes' as Municipio union all
	select 'SP' as Estado, 'Narandiba' as Municipio union all
	select 'SP' as Estado, 'Natividade da Serra' as Municipio union all
	select 'SP' as Estado, 'Nazaré Paulista' as Municipio union all
	select 'SP' as Estado, 'Neves Paulista' as Municipio union all
	select 'SP' as Estado, 'Nhandeara' as Municipio union all
	select 'SP' as Estado, 'Nipoã' as Municipio union all
	select 'SP' as Estado, 'Nova Aliança' as Municipio union all
	select 'SP' as Estado, 'Nova Campina' as Municipio union all
	select 'SP' as Estado, 'Nova Canaã Paulista' as Municipio union all
	select 'SP' as Estado, 'Nova Castilho' as Municipio union all
	select 'SP' as Estado, 'Nova Europa' as Municipio union all
	select 'SP' as Estado, 'Nova Granada' as Municipio union all
	select 'SP' as Estado, 'Nova Guataporanga' as Municipio union all
	select 'SP' as Estado, 'Nova Independência' as Municipio union all
	select 'SP' as Estado, 'Nova Luzitânia' as Municipio union all
	select 'SP' as Estado, 'Nova Odessa' as Municipio union all
	select 'SP' as Estado, 'Novais' as Municipio union all
	select 'SP' as Estado, 'Novo Horizonte' as Municipio union all
	select 'SP' as Estado, 'Nuporanga' as Municipio union all
	select 'SP' as Estado, 'Ocauçu' as Municipio union all
	select 'SP' as Estado, 'Óleo' as Municipio union all
	select 'SP' as Estado, 'Olímpia' as Municipio union all
	select 'SP' as Estado, 'Onda Verde' as Municipio union all
	select 'SP' as Estado, 'Oriente' as Municipio union all
	select 'SP' as Estado, 'Orindiúva' as Municipio union all
	select 'SP' as Estado, 'Orlândia' as Municipio union all
	select 'SP' as Estado, 'Osasco' as Municipio union all
	select 'SP' as Estado, 'Oscar Bressane' as Municipio union all
	select 'SP' as Estado, 'Osvaldo Cruz' as Municipio union all
	select 'SP' as Estado, 'Ourinhos' as Municipio union all
	select 'SP' as Estado, 'Ouro Verde' as Municipio union all
	select 'SP' as Estado, 'Ouroeste' as Municipio union all
	select 'SP' as Estado, 'Pacaembu' as Municipio union all
	select 'SP' as Estado, 'Palestina' as Municipio union all
	select 'SP' as Estado, 'Palmares Paulista' as Municipio union all
	select 'SP' as Estado, 'Palmeira d''Oeste' as Municipio union all
	select 'SP' as Estado, 'Palmital' as Municipio union all
	select 'SP' as Estado, 'Panorama' as Municipio union all
	select 'SP' as Estado, 'Paraguaçu Paulista' as Municipio union all
	select 'SP' as Estado, 'Paraibuna' as Municipio union all
	select 'SP' as Estado, 'Paraíso' as Municipio union all
	select 'SP' as Estado, 'Paranapanema' as Municipio union all
	select 'SP' as Estado, 'Paranapuã' as Municipio union all
	select 'SP' as Estado, 'Parapuã' as Municipio union all
	select 'SP' as Estado, 'Pardinho' as Municipio union all
	select 'SP' as Estado, 'Pariquera-Açu' as Municipio union all
	select 'SP' as Estado, 'Parisi' as Municipio union all
	select 'SP' as Estado, 'Patrocínio Paulista' as Municipio union all
	select 'SP' as Estado, 'Paulicéia' as Municipio union all
	select 'SP' as Estado, 'Paulínia' as Municipio union all
	select 'SP' as Estado, 'Paulistânia' as Municipio union all
	select 'SP' as Estado, 'Paulo de Faria' as Municipio union all
	select 'SP' as Estado, 'Pederneiras' as Municipio union all
	select 'SP' as Estado, 'Pedra Bela' as Municipio union all
	select 'SP' as Estado, 'Pedranópolis' as Municipio union all
	select 'SP' as Estado, 'Pedregulho' as Municipio union all
	select 'SP' as Estado, 'Pedreira' as Municipio union all
	select 'SP' as Estado, 'Pedrinhas Paulista' as Municipio union all
	select 'SP' as Estado, 'Pedro de Toledo' as Municipio union all
	select 'SP' as Estado, 'Penápolis' as Municipio union all
	select 'SP' as Estado, 'Pereira Barreto' as Municipio union all
	select 'SP' as Estado, 'Pereiras' as Municipio union all
	select 'SP' as Estado, 'Peruíbe' as Municipio union all
	select 'SP' as Estado, 'Piacatu' as Municipio union all
	select 'SP' as Estado, 'Piedade' as Municipio union all
	select 'SP' as Estado, 'Pilar do Sul' as Municipio union all
	select 'SP' as Estado, 'Pindamonhangaba' as Municipio union all
	select 'SP' as Estado, 'Pindorama' as Municipio union all
	select 'SP' as Estado, 'Pinhalzinho' as Municipio union all
	select 'SP' as Estado, 'Piquerobi' as Municipio union all
	select 'SP' as Estado, 'Piquete' as Municipio union all
	select 'SP' as Estado, 'Piracaia' as Municipio union all
	select 'SP' as Estado, 'Piracicaba' as Municipio union all
	select 'SP' as Estado, 'Piraju' as Municipio union all
	select 'SP' as Estado, 'Pirajuí' as Municipio union all
	select 'SP' as Estado, 'Pirangi' as Municipio union all
	select 'SP' as Estado, 'Pirapora do Bom Jesus' as Municipio union all
	select 'SP' as Estado, 'Pirapozinho' as Municipio union all
	select 'SP' as Estado, 'Pirassununga' as Municipio union all
	select 'SP' as Estado, 'Piratininga' as Municipio union all
	select 'SP' as Estado, 'Pitangueiras' as Municipio union all
	select 'SP' as Estado, 'Planalto' as Municipio union all
	select 'SP' as Estado, 'Platina' as Municipio union all
	select 'SP' as Estado, 'Poá' as Municipio union all
	select 'SP' as Estado, 'Poloni' as Municipio union all
	select 'SP' as Estado, 'Pompéia' as Municipio union all
	select 'SP' as Estado, 'Pongaí' as Municipio union all
	select 'SP' as Estado, 'Pontal' as Municipio union all
	select 'SP' as Estado, 'Pontalinda' as Municipio union all
	select 'SP' as Estado, 'Pontes Gestal' as Municipio union all
	select 'SP' as Estado, 'Populina' as Municipio union all
	select 'SP' as Estado, 'Porangaba' as Municipio union all
	select 'SP' as Estado, 'Porto Feliz' as Municipio union all
	select 'SP' as Estado, 'Porto Ferreira' as Municipio union all
	select 'SP' as Estado, 'Potim' as Municipio union all
	select 'SP' as Estado, 'Potirendaba' as Municipio union all
	select 'SP' as Estado, 'Pracinha' as Municipio union all
	select 'SP' as Estado, 'Pradópolis' as Municipio union all
	select 'SP' as Estado, 'Praia Grande' as Municipio union all
	select 'SP' as Estado, 'Pratânia' as Municipio union all
	select 'SP' as Estado, 'Presidente Alves' as Municipio union all
	select 'SP' as Estado, 'Presidente Bernardes' as Municipio union all
	select 'SP' as Estado, 'Presidente Epitácio' as Municipio union all
	select 'SP' as Estado, 'Presidente Prudente' as Municipio union all
	select 'SP' as Estado, 'Presidente Venceslau' as Municipio union all
	select 'SP' as Estado, 'Promissão' as Municipio union all
	select 'SP' as Estado, 'Quadra' as Municipio union all
	select 'SP' as Estado, 'Quatá' as Municipio union all
	select 'SP' as Estado, 'Queiroz' as Municipio union all
	select 'SP' as Estado, 'Queluz' as Municipio union all
	select 'SP' as Estado, 'Quintana' as Municipio union all
	select 'SP' as Estado, 'Rafard' as Municipio union all
	select 'SP' as Estado, 'Rancharia' as Municipio union all
	select 'SP' as Estado, 'Redenção da Serra' as Municipio union all
	select 'SP' as Estado, 'Regente Feijó' as Municipio union all
	select 'SP' as Estado, 'Reginópolis' as Municipio union all
	select 'SP' as Estado, 'Registro' as Municipio union all
	select 'SP' as Estado, 'Restinga' as Municipio union all
	select 'SP' as Estado, 'Ribeira' as Municipio union all
	select 'SP' as Estado, 'Ribeirão Bonito' as Municipio union all
	select 'SP' as Estado, 'Ribeirão Branco' as Municipio union all
	select 'SP' as Estado, 'Ribeirão Corrente' as Municipio union all
	select 'SP' as Estado, 'Ribeirão do Sul' as Municipio union all
	select 'SP' as Estado, 'Ribeirão dos Índios' as Municipio union all
	select 'SP' as Estado, 'Ribeirão Grande' as Municipio union all
	select 'SP' as Estado, 'Ribeirão Pires' as Municipio union all
	select 'SP' as Estado, 'Ribeirão Preto' as Municipio union all
	select 'SP' as Estado, 'Rifaina' as Municipio union all
	select 'SP' as Estado, 'Rincão' as Municipio union all
	select 'SP' as Estado, 'Rinópolis' as Municipio union all
	select 'SP' as Estado, 'Rio Claro' as Municipio union all
	select 'SP' as Estado, 'Rio das Pedras' as Municipio union all
	select 'SP' as Estado, 'Rio Grande da Serra' as Municipio union all
	select 'SP' as Estado, 'Riolândia' as Municipio union all
	select 'SP' as Estado, 'Riversul' as Municipio union all
	select 'SP' as Estado, 'Rosana' as Municipio union all
	select 'SP' as Estado, 'Roseira' as Municipio union all
	select 'SP' as Estado, 'Rubiácea' as Municipio union all
	select 'SP' as Estado, 'Rubinéia' as Municipio union all
	select 'SP' as Estado, 'Sabino' as Municipio union all
	select 'SP' as Estado, 'Sagres' as Municipio union all
	select 'SP' as Estado, 'Sales' as Municipio union all
	select 'SP' as Estado, 'Sales Oliveira' as Municipio union all
	select 'SP' as Estado, 'Salesópolis' as Municipio union all
	select 'SP' as Estado, 'Salmourão' as Municipio union all
	select 'SP' as Estado, 'Saltinho' as Municipio union all
	select 'SP' as Estado, 'Salto' as Municipio union all
	select 'SP' as Estado, 'Salto de Pirapora' as Municipio union all
	select 'SP' as Estado, 'Salto Grande' as Municipio union all
	select 'SP' as Estado, 'Sandovalina' as Municipio union all
	select 'SP' as Estado, 'Santa Adélia' as Municipio union all
	select 'SP' as Estado, 'Santa Albertina' as Municipio union all
	select 'SP' as Estado, 'Santa Bárbara d''Oeste' as Municipio union all
	select 'SP' as Estado, 'Santa Branca' as Municipio union all
	select 'SP' as Estado, 'Santa Clara d''Oeste' as Municipio union all
	select 'SP' as Estado, 'Santa Cruz da Conceição' as Municipio union all
	select 'SP' as Estado, 'Santa Cruz da Esperança' as Municipio union all
	select 'SP' as Estado, 'Santa Cruz das Palmeiras' as Municipio union all
	select 'SP' as Estado, 'Santa Cruz do Rio Pardo' as Municipio union all
	select 'SP' as Estado, 'Santa Ernestina' as Municipio union all
	select 'SP' as Estado, 'Santa Fé do Sul' as Municipio union all
	select 'SP' as Estado, 'Santa Gertrudes' as Municipio union all
	select 'SP' as Estado, 'Santa Isabel' as Municipio union all
	select 'SP' as Estado, 'Santa Lúcia' as Municipio union all
	select 'SP' as Estado, 'Santa Maria da Serra' as Municipio union all
	select 'SP' as Estado, 'Santa Mercedes' as Municipio union all
	select 'SP' as Estado, 'Santa Rita do Passa Quatro' as Municipio union all
	select 'SP' as Estado, 'Santa Rita d''Oeste' as Municipio union all
	select 'SP' as Estado, 'Santa Rosa de Viterbo' as Municipio union all
	select 'SP' as Estado, 'Santa Salete' as Municipio union all
	select 'SP' as Estado, 'Santana da Ponte Pensa' as Municipio union all
	select 'SP' as Estado, 'Santana de Parnaíba' as Municipio union all
	select 'SP' as Estado, 'Santo Anastácio' as Municipio union all
	select 'SP' as Estado, 'Santo André' as Municipio union all
	select 'SP' as Estado, 'Santo Antônio da Alegria' as Municipio union all
	select 'SP' as Estado, 'Santo Antônio de Posse' as Municipio union all
	select 'SP' as Estado, 'Santo Antônio do Aracanguá' as Municipio union all
	select 'SP' as Estado, 'Santo Antônio do Jardim' as Municipio union all
	select 'SP' as Estado, 'Santo Antônio do Pinhal' as Municipio union all
	select 'SP' as Estado, 'Santo Expedito' as Municipio union all
	select 'SP' as Estado, 'Santópolis do Aguapeí' as Municipio union all
	select 'SP' as Estado, 'Santos' as Municipio union all
	select 'SP' as Estado, 'São Bento do Sapucaí' as Municipio union all
	select 'SP' as Estado, 'São Bernardo do Campo' as Municipio union all
	select 'SP' as Estado, 'São Caetano do Sul' as Municipio union all
	select 'SP' as Estado, 'São Carlos' as Municipio union all
	select 'SP' as Estado, 'São Francisco' as Municipio union all
	select 'SP' as Estado, 'São João da Boa Vista' as Municipio union all
	select 'SP' as Estado, 'São João das Duas Pontes' as Municipio union all
	select 'SP' as Estado, 'São João de Iracema' as Municipio union all
	select 'SP' as Estado, 'São João do Pau d''Alho' as Municipio union all
	select 'SP' as Estado, 'São Joaquim da Barra' as Municipio union all
	select 'SP' as Estado, 'São José da Bela Vista' as Municipio union all
	select 'SP' as Estado, 'São José do Barreiro' as Municipio union all
	select 'SP' as Estado, 'São José do Rio Pardo' as Municipio union all
	select 'SP' as Estado, 'São José do Rio Preto' as Municipio union all
	select 'SP' as Estado, 'São José dos Campos' as Municipio union all
	select 'SP' as Estado, 'São Lourenço da Serra' as Municipio union all
	select 'SP' as Estado, 'São Luís do Paraitinga' as Municipio union all
	select 'SP' as Estado, 'São Manuel' as Municipio union all
	select 'SP' as Estado, 'São Miguel Arcanjo' as Municipio union all
	select 'SP' as Estado, 'São Paulo' as Municipio union all
	select 'SP' as Estado, 'São Pedro' as Municipio union all
	select 'SP' as Estado, 'São Pedro do Turvo' as Municipio union all
	select 'SP' as Estado, 'São Roque' as Municipio union all
	select 'SP' as Estado, 'São Sebastião' as Municipio union all
	select 'SP' as Estado, 'São Sebastião da Grama' as Municipio union all
	select 'SP' as Estado, 'São Simão' as Municipio union all
	select 'SP' as Estado, 'São Vicente' as Municipio union all
	select 'SP' as Estado, 'Sarapuí' as Municipio union all
	select 'SP' as Estado, 'Sarutaiá' as Municipio union all
	select 'SP' as Estado, 'Sebastianópolis do Sul' as Municipio union all
	select 'SP' as Estado, 'Serra Azul' as Municipio union all
	select 'SP' as Estado, 'Serra Negra' as Municipio union all
	select 'SP' as Estado, 'Serrana' as Municipio union all
	select 'SP' as Estado, 'Sertãozinho' as Municipio union all
	select 'SP' as Estado, 'Sete Barras' as Municipio union all
	select 'SP' as Estado, 'Severínia' as Municipio union all
	select 'SP' as Estado, 'Silveiras' as Municipio union all
	select 'SP' as Estado, 'Socorro' as Municipio union all
	select 'SP' as Estado, 'Sorocaba' as Municipio union all
	select 'SP' as Estado, 'Sud Mennucci' as Municipio union all
	select 'SP' as Estado, 'Sumaré' as Municipio union all
	select 'SP' as Estado, 'Suzanápolis' as Municipio union all
	select 'SP' as Estado, 'Suzano' as Municipio union all
	select 'SP' as Estado, 'Tabapuã' as Municipio union all
	select 'SP' as Estado, 'Tabatinga' as Municipio union all
	select 'SP' as Estado, 'Taboão da Serra' as Municipio union all
	select 'SP' as Estado, 'Taciba' as Municipio union all
	select 'SP' as Estado, 'Taguaí' as Municipio union all
	select 'SP' as Estado, 'Taiaçu' as Municipio union all
	select 'SP' as Estado, 'Taiúva' as Municipio union all
	select 'SP' as Estado, 'Tambaú' as Municipio union all
	select 'SP' as Estado, 'Tanabi' as Municipio union all
	select 'SP' as Estado, 'Tapiraí' as Municipio union all
	select 'SP' as Estado, 'Tapiratiba' as Municipio union all
	select 'SP' as Estado, 'Taquaral' as Municipio union all
	select 'SP' as Estado, 'Taquaritinga' as Municipio union all
	select 'SP' as Estado, 'Taquarituba' as Municipio union all
	select 'SP' as Estado, 'Taquarivaí' as Municipio union all
	select 'SP' as Estado, 'Tarabai' as Municipio union all
	select 'SP' as Estado, 'Tarumã' as Municipio union all
	select 'SP' as Estado, 'Tatuí' as Municipio union all
	select 'SP' as Estado, 'Taubaté' as Municipio union all
	select 'SP' as Estado, 'Tejupá' as Municipio union all
	select 'SP' as Estado, 'Teodoro Sampaio' as Municipio union all
	select 'SP' as Estado, 'Terra Roxa' as Municipio union all
	select 'SP' as Estado, 'Tietê' as Municipio union all
	select 'SP' as Estado, 'Timburi' as Municipio union all
	select 'SP' as Estado, 'Torre de Pedra' as Municipio union all
	select 'SP' as Estado, 'Torrinha' as Municipio union all
	select 'SP' as Estado, 'Trabiju' as Municipio union all
	select 'SP' as Estado, 'Tremembé' as Municipio union all
	select 'SP' as Estado, 'Três Fronteiras' as Municipio union all
	select 'SP' as Estado, 'Tuiuti' as Municipio union all
	select 'SP' as Estado, 'Tupã' as Municipio union all
	select 'SP' as Estado, 'Tupi Paulista' as Municipio union all
	select 'SP' as Estado, 'Turiúba' as Municipio union all
	select 'SP' as Estado, 'Turmalina' as Municipio union all
	select 'SP' as Estado, 'Ubarana' as Municipio union all
	select 'SP' as Estado, 'Ubatuba' as Municipio union all
	select 'SP' as Estado, 'Ubirajara' as Municipio union all
	select 'SP' as Estado, 'Uchoa' as Municipio union all
	select 'SP' as Estado, 'União Paulista' as Municipio union all
	select 'SP' as Estado, 'Urânia' as Municipio union all
	select 'SP' as Estado, 'Uru' as Municipio union all
	select 'SP' as Estado, 'Urupês' as Municipio union all
	select 'SP' as Estado, 'Valentim Gentil' as Municipio union all
	select 'SP' as Estado, 'Valinhos' as Municipio union all
	select 'SP' as Estado, 'Valparaíso' as Municipio union all
	select 'SP' as Estado, 'Vargem' as Municipio union all
	select 'SP' as Estado, 'Vargem Grande do Sul' as Municipio union all
	select 'SP' as Estado, 'Vargem Grande Paulista' as Municipio union all
	select 'SP' as Estado, 'Várzea Paulista' as Municipio union all
	select 'SP' as Estado, 'Vera Cruz' as Municipio union all
	select 'SP' as Estado, 'Vinhedo' as Municipio union all
	select 'SP' as Estado, 'Viradouro' as Municipio union all
	select 'SP' as Estado, 'Vista Alegre do Alto' as Municipio union all
	select 'SP' as Estado, 'Vitória Brasil' as Municipio union all
	select 'SP' as Estado, 'Votorantim' as Municipio union all
	select 'SP' as Estado, 'Votuporanga' as Municipio union all
	select 'SP' as Estado, 'Zacarias' as Municipio union all
	select 'PR' as Estado, 'Abatiá' as Municipio union all
	select 'PR' as Estado, 'Adrianópolis' as Municipio union all
	select 'PR' as Estado, 'Agudos do Sul' as Municipio union all
	select 'PR' as Estado, 'Almirante Tamandaré' as Municipio union all
	select 'PR' as Estado, 'Altamira do Paraná' as Municipio union all
	select 'PR' as Estado, 'Alto Paraíso' as Municipio union all
	select 'PR' as Estado, 'Alto Paraná' as Municipio union all
	select 'PR' as Estado, 'Alto Piquiri' as Municipio union all
	select 'PR' as Estado, 'Altônia' as Municipio union all
	select 'PR' as Estado, 'Alvorada do Sul' as Municipio union all
	select 'PR' as Estado, 'Amaporã' as Municipio union all
	select 'PR' as Estado, 'Ampére' as Municipio union all
	select 'PR' as Estado, 'Anahy' as Municipio union all
	select 'PR' as Estado, 'Andirá' as Municipio union all
	select 'PR' as Estado, 'Ângulo' as Municipio union all
	select 'PR' as Estado, 'Antonina' as Municipio union all
	select 'PR' as Estado, 'Antônio Olinto' as Municipio union all
	select 'PR' as Estado, 'Apucarana' as Municipio union all
	select 'PR' as Estado, 'Arapongas' as Municipio union all
	select 'PR' as Estado, 'Arapoti' as Municipio union all
	select 'PR' as Estado, 'Arapuã' as Municipio union all
	select 'PR' as Estado, 'Araruna' as Municipio union all
	select 'PR' as Estado, 'Araucária' as Municipio union all
	select 'PR' as Estado, 'Ariranha do Ivaí' as Municipio union all
	select 'PR' as Estado, 'Assaí' as Municipio union all
	select 'PR' as Estado, 'Assis Chateaubriand' as Municipio union all
	select 'PR' as Estado, 'Astorga' as Municipio union all
	select 'PR' as Estado, 'Atalaia' as Municipio union all
	select 'PR' as Estado, 'Balsa Nova' as Municipio union all
	select 'PR' as Estado, 'Bandeirantes' as Municipio union all
	select 'PR' as Estado, 'Barbosa Ferraz' as Municipio union all
	select 'PR' as Estado, 'Barra do Jacaré' as Municipio union all
	select 'PR' as Estado, 'Barracão' as Municipio union all
	select 'PR' as Estado, 'Bela Vista da Caroba' as Municipio union all
	select 'PR' as Estado, 'Bela Vista do Paraíso' as Municipio union all
	select 'PR' as Estado, 'Bituruna' as Municipio union all
	select 'PR' as Estado, 'Boa Esperança' as Municipio union all
	select 'PR' as Estado, 'Boa Esperança do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Boa Ventura de São Roque' as Municipio union all
	select 'PR' as Estado, 'Boa Vista da Aparecida' as Municipio union all
	select 'PR' as Estado, 'Bocaiúva do Sul' as Municipio union all
	select 'PR' as Estado, 'Bom Jesus do Sul' as Municipio union all
	select 'PR' as Estado, 'Bom Sucesso' as Municipio union all
	select 'PR' as Estado, 'Bom Sucesso do Sul' as Municipio union all
	select 'PR' as Estado, 'Borrazópolis' as Municipio union all
	select 'PR' as Estado, 'Braganey' as Municipio union all
	select 'PR' as Estado, 'Brasilândia do Sul' as Municipio union all
	select 'PR' as Estado, 'Cafeara' as Municipio union all
	select 'PR' as Estado, 'Cafelândia' as Municipio union all
	select 'PR' as Estado, 'Cafezal do Sul' as Municipio union all
	select 'PR' as Estado, 'Califórnia' as Municipio union all
	select 'PR' as Estado, 'Cambará' as Municipio union all
	select 'PR' as Estado, 'Cambé' as Municipio union all
	select 'PR' as Estado, 'Cambira' as Municipio union all
	select 'PR' as Estado, 'Campina da Lagoa' as Municipio union all
	select 'PR' as Estado, 'Campina do Simão' as Municipio union all
	select 'PR' as Estado, 'Campina Grande do Sul' as Municipio union all
	select 'PR' as Estado, 'Campo Bonito' as Municipio union all
	select 'PR' as Estado, 'Campo do Tenente' as Municipio union all
	select 'PR' as Estado, 'Campo Largo' as Municipio union all
	select 'PR' as Estado, 'Campo Magro' as Municipio union all
	select 'PR' as Estado, 'Campo Mourão' as Municipio union all
	select 'PR' as Estado, 'Cândido de Abreu' as Municipio union all
	select 'PR' as Estado, 'Candói' as Municipio union all
	select 'PR' as Estado, 'Cantagalo' as Municipio union all
	select 'PR' as Estado, 'Capanema' as Municipio union all
	select 'PR' as Estado, 'Capitão Leônidas Marques' as Municipio union all
	select 'PR' as Estado, 'Carambeí' as Municipio union all
	select 'PR' as Estado, 'Carlópolis' as Municipio union all
	select 'PR' as Estado, 'Cascavel' as Municipio union all
	select 'PR' as Estado, 'Castro' as Municipio union all
	select 'PR' as Estado, 'Catanduvas' as Municipio union all
	select 'PR' as Estado, 'Centenário do Sul' as Municipio union all
	select 'PR' as Estado, 'Cerro Azul' as Municipio union all
	select 'PR' as Estado, 'Céu Azul' as Municipio union all
	select 'PR' as Estado, 'Chopinzinho' as Municipio union all
	select 'PR' as Estado, 'Cianorte' as Municipio union all
	select 'PR' as Estado, 'Cidade Gaúcha' as Municipio union all
	select 'PR' as Estado, 'Clevelândia' as Municipio union all
	select 'PR' as Estado, 'Colombo' as Municipio union all
	select 'PR' as Estado, 'Colorado' as Municipio union all
	select 'PR' as Estado, 'Congonhinhas' as Municipio union all
	select 'PR' as Estado, 'Conselheiro Mairinck' as Municipio union all
	select 'PR' as Estado, 'Contenda' as Municipio union all
	select 'PR' as Estado, 'Corbélia' as Municipio union all
	select 'PR' as Estado, 'Cornélio Procópio' as Municipio union all
	select 'PR' as Estado, 'Coronel Domingos Soares' as Municipio union all
	select 'PR' as Estado, 'Coronel Vivida' as Municipio union all
	select 'PR' as Estado, 'Corumbataí do Sul' as Municipio union all
	select 'PR' as Estado, 'Cruz Machado' as Municipio union all
	select 'PR' as Estado, 'Cruzeiro do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Cruzeiro do Oeste' as Municipio union all
	select 'PR' as Estado, 'Cruzeiro do Sul' as Municipio union all
	select 'PR' as Estado, 'Cruzmaltina' as Municipio union all
	select 'PR' as Estado, 'Curitiba' as Municipio union all
	select 'PR' as Estado, 'Curiúva' as Municipio union all
	select 'PR' as Estado, 'Diamante do Norte' as Municipio union all
	select 'PR' as Estado, 'Diamante do Sul' as Municipio union all
	select 'PR' as Estado, 'Diamante D''Oeste' as Municipio union all
	select 'PR' as Estado, 'Dois Vizinhos' as Municipio union all
	select 'PR' as Estado, 'Douradina' as Municipio union all
	select 'PR' as Estado, 'Doutor Camargo' as Municipio union all
	select 'PR' as Estado, 'Doutor Ulysses' as Municipio union all
	select 'PR' as Estado, 'Enéas Marques' as Municipio union all
	select 'PR' as Estado, 'Engenheiro Beltrão' as Municipio union all
	select 'PR' as Estado, 'Entre Rios do Oeste' as Municipio union all
	select 'PR' as Estado, 'Esperança Nova' as Municipio union all
	select 'PR' as Estado, 'Espigão Alto do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Farol' as Municipio union all
	select 'PR' as Estado, 'Faxinal' as Municipio union all
	select 'PR' as Estado, 'Fazenda Rio Grande' as Municipio union all
	select 'PR' as Estado, 'Fênix' as Municipio union all
	select 'PR' as Estado, 'Fernandes Pinheiro' as Municipio union all
	select 'PR' as Estado, 'Figueira' as Municipio union all
	select 'PR' as Estado, 'Flor da Serra do Sul' as Municipio union all
	select 'PR' as Estado, 'Floraí' as Municipio union all
	select 'PR' as Estado, 'Floresta' as Municipio union all
	select 'PR' as Estado, 'Florestópolis' as Municipio union all
	select 'PR' as Estado, 'Flórida' as Municipio union all
	select 'PR' as Estado, 'Formosa do Oeste' as Municipio union all
	select 'PR' as Estado, 'Foz do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Foz do Jordão' as Municipio union all
	select 'PR' as Estado, 'Francisco Alves' as Municipio union all
	select 'PR' as Estado, 'Francisco Beltrão' as Municipio union all
	select 'PR' as Estado, 'General Carneiro' as Municipio union all
	select 'PR' as Estado, 'Godoy Moreira' as Municipio union all
	select 'PR' as Estado, 'Goioerê' as Municipio union all
	select 'PR' as Estado, 'Goioxim' as Municipio union all
	select 'PR' as Estado, 'Grandes Rios' as Municipio union all
	select 'PR' as Estado, 'Guaíra' as Municipio union all
	select 'PR' as Estado, 'Guairaçá' as Municipio union all
	select 'PR' as Estado, 'Guamiranga' as Municipio union all
	select 'PR' as Estado, 'Guapirama' as Municipio union all
	select 'PR' as Estado, 'Guaporema' as Municipio union all
	select 'PR' as Estado, 'Guaraci' as Municipio union all
	select 'PR' as Estado, 'Guaraniaçu' as Municipio union all
	select 'PR' as Estado, 'Guarapuava' as Municipio union all
	select 'PR' as Estado, 'Guaraqueçaba' as Municipio union all
	select 'PR' as Estado, 'Guaratuba' as Municipio union all
	select 'PR' as Estado, 'Honório Serpa' as Municipio union all
	select 'PR' as Estado, 'Ibaiti' as Municipio union all
	select 'PR' as Estado, 'Ibema' as Municipio union all
	select 'PR' as Estado, 'Ibiporã' as Municipio union all
	select 'PR' as Estado, 'Icaraíma' as Municipio union all
	select 'PR' as Estado, 'Iguaraçu' as Municipio union all
	select 'PR' as Estado, 'Iguatu' as Municipio union all
	select 'PR' as Estado, 'Imbaú' as Municipio union all
	select 'PR' as Estado, 'Imbituva' as Municipio union all
	select 'PR' as Estado, 'Inácio Martins' as Municipio union all
	select 'PR' as Estado, 'Inajá' as Municipio union all
	select 'PR' as Estado, 'Indianópolis' as Municipio union all
	select 'PR' as Estado, 'Ipiranga' as Municipio union all
	select 'PR' as Estado, 'Iporã' as Municipio union all
	select 'PR' as Estado, 'Iracema do Oeste' as Municipio union all
	select 'PR' as Estado, 'Irati' as Municipio union all
	select 'PR' as Estado, 'Iretama' as Municipio union all
	select 'PR' as Estado, 'Itaguajé' as Municipio union all
	select 'PR' as Estado, 'Itaipulândia' as Municipio union all
	select 'PR' as Estado, 'Itambaracá' as Municipio union all
	select 'PR' as Estado, 'Itambé' as Municipio union all
	select 'PR' as Estado, 'Itapejara d''Oeste' as Municipio union all
	select 'PR' as Estado, 'Itaperuçu' as Municipio union all
	select 'PR' as Estado, 'Itaúna do Sul' as Municipio union all
	select 'PR' as Estado, 'Ivaí' as Municipio union all
	select 'PR' as Estado, 'Ivaiporã' as Municipio union all
	select 'PR' as Estado, 'Ivaté' as Municipio union all
	select 'PR' as Estado, 'Ivatuba' as Municipio union all
	select 'PR' as Estado, 'Jaboti' as Municipio union all
	select 'PR' as Estado, 'Jacarezinho' as Municipio union all
	select 'PR' as Estado, 'Jaguapitã' as Municipio union all
	select 'PR' as Estado, 'Jaguariaíva' as Municipio union all
	select 'PR' as Estado, 'Jandaia do Sul' as Municipio union all
	select 'PR' as Estado, 'Janiópolis' as Municipio union all
	select 'PR' as Estado, 'Japira' as Municipio union all
	select 'PR' as Estado, 'Japurá' as Municipio union all
	select 'PR' as Estado, 'Jardim Alegre' as Municipio union all
	select 'PR' as Estado, 'Jardim Olinda' as Municipio union all
	select 'PR' as Estado, 'Jataizinho' as Municipio union all
	select 'PR' as Estado, 'Jesuítas' as Municipio union all
	select 'PR' as Estado, 'Joaquim Távora' as Municipio union all
	select 'PR' as Estado, 'Jundiaí do Sul' as Municipio union all
	select 'PR' as Estado, 'Juranda' as Municipio union all
	select 'PR' as Estado, 'Jussara' as Municipio union all
	select 'PR' as Estado, 'Kaloré' as Municipio union all
	select 'PR' as Estado, 'Lapa' as Municipio union all
	select 'PR' as Estado, 'Laranjal' as Municipio union all
	select 'PR' as Estado, 'Laranjeiras do Sul' as Municipio union all
	select 'PR' as Estado, 'Leópolis' as Municipio union all
	select 'PR' as Estado, 'Lidianópolis' as Municipio union all
	select 'PR' as Estado, 'Lindoeste' as Municipio union all
	select 'PR' as Estado, 'Loanda' as Municipio union all
	select 'PR' as Estado, 'Lobato' as Municipio union all
	select 'PR' as Estado, 'Londrina' as Municipio union all
	select 'PR' as Estado, 'Luiziana' as Municipio union all
	select 'PR' as Estado, 'Lunardelli' as Municipio union all
	select 'PR' as Estado, 'Lupionópolis' as Municipio union all
	select 'PR' as Estado, 'Mallet' as Municipio union all
	select 'PR' as Estado, 'Mamborê' as Municipio union all
	select 'PR' as Estado, 'Mandaguaçu' as Municipio union all
	select 'PR' as Estado, 'Mandaguari' as Municipio union all
	select 'PR' as Estado, 'Mandirituba' as Municipio union all
	select 'PR' as Estado, 'Manfrinópolis' as Municipio union all
	select 'PR' as Estado, 'Mangueirinha' as Municipio union all
	select 'PR' as Estado, 'Manoel Ribas' as Municipio union all
	select 'PR' as Estado, 'Marechal Cândido Rondon' as Municipio union all
	select 'PR' as Estado, 'Maria Helena' as Municipio union all
	select 'PR' as Estado, 'Marialva' as Municipio union all
	select 'PR' as Estado, 'Marilândia do Sul' as Municipio union all
	select 'PR' as Estado, 'Marilena' as Municipio union all
	select 'PR' as Estado, 'Mariluz' as Municipio union all
	select 'PR' as Estado, 'Maringá' as Municipio union all
	select 'PR' as Estado, 'Mariópolis' as Municipio union all
	select 'PR' as Estado, 'Maripá' as Municipio union all
	select 'PR' as Estado, 'Marmeleiro' as Municipio union all
	select 'PR' as Estado, 'Marquinho' as Municipio union all
	select 'PR' as Estado, 'Marumbi' as Municipio union all
	select 'PR' as Estado, 'Matelândia' as Municipio union all
	select 'PR' as Estado, 'Matinhos' as Municipio union all
	select 'PR' as Estado, 'Mato Rico' as Municipio union all
	select 'PR' as Estado, 'Mauá da Serra' as Municipio union all
	select 'PR' as Estado, 'Medianeira' as Municipio union all
	select 'PR' as Estado, 'Mercedes' as Municipio union all
	select 'PR' as Estado, 'Mirador' as Municipio union all
	select 'PR' as Estado, 'Miraselva' as Municipio union all
	select 'PR' as Estado, 'Missal' as Municipio union all
	select 'PR' as Estado, 'Moreira Sales' as Municipio union all
	select 'PR' as Estado, 'Morretes' as Municipio union all
	select 'PR' as Estado, 'Munhoz de Melo' as Municipio union all
	select 'PR' as Estado, 'Nossa Senhora das Graças' as Municipio union all
	select 'PR' as Estado, 'Nova Aliança do Ivaí' as Municipio union all
	select 'PR' as Estado, 'Nova América da Colina' as Municipio union all
	select 'PR' as Estado, 'Nova Aurora' as Municipio union all
	select 'PR' as Estado, 'Nova Cantu' as Municipio union all
	select 'PR' as Estado, 'Nova Esperança' as Municipio union all
	select 'PR' as Estado, 'Nova Esperança do Sudoeste' as Municipio union all
	select 'PR' as Estado, 'Nova Fátima' as Municipio union all
	select 'PR' as Estado, 'Nova Laranjeiras' as Municipio union all
	select 'PR' as Estado, 'Nova Londrina' as Municipio union all
	select 'PR' as Estado, 'Nova Olímpia' as Municipio union all
	select 'PR' as Estado, 'Nova Prata do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Nova Santa Bárbara' as Municipio union all
	select 'PR' as Estado, 'Nova Santa Rosa' as Municipio union all
	select 'PR' as Estado, 'Nova Tebas' as Municipio union all
	select 'PR' as Estado, 'Novo Itacolomi' as Municipio union all
	select 'PR' as Estado, 'Ortigueira' as Municipio union all
	select 'PR' as Estado, 'Ourizona' as Municipio union all
	select 'PR' as Estado, 'Ouro Verde do Oeste' as Municipio union all
	select 'PR' as Estado, 'Paiçandu' as Municipio union all
	select 'PR' as Estado, 'Palmas' as Municipio union all
	select 'PR' as Estado, 'Palmeira' as Municipio union all
	select 'PR' as Estado, 'Palmital' as Municipio union all
	select 'PR' as Estado, 'Palotina' as Municipio union all
	select 'PR' as Estado, 'Paraíso do Norte' as Municipio union all
	select 'PR' as Estado, 'Paranacity' as Municipio union all
	select 'PR' as Estado, 'Paranaguá' as Municipio union all
	select 'PR' as Estado, 'Paranapoema' as Municipio union all
	select 'PR' as Estado, 'Paranavaí' as Municipio union all
	select 'PR' as Estado, 'Pato Bragado' as Municipio union all
	select 'PR' as Estado, 'Pato Branco' as Municipio union all
	select 'PR' as Estado, 'Paula Freitas' as Municipio union all
	select 'PR' as Estado, 'Paulo Frontin' as Municipio union all
	select 'PR' as Estado, 'Peabiru' as Municipio union all
	select 'PR' as Estado, 'Perobal' as Municipio union all
	select 'PR' as Estado, 'Pérola' as Municipio union all
	select 'PR' as Estado, 'Pérola d''Oeste' as Municipio union all
	select 'PR' as Estado, 'Piên' as Municipio union all
	select 'PR' as Estado, 'Pinhais' as Municipio union all
	select 'PR' as Estado, 'Pinhal de São Bento' as Municipio union all
	select 'PR' as Estado, 'Pinhalão' as Municipio union all
	select 'PR' as Estado, 'Pinhão' as Municipio union all
	select 'PR' as Estado, 'Piraí do Sul' as Municipio union all
	select 'PR' as Estado, 'Piraquara' as Municipio union all
	select 'PR' as Estado, 'Pitanga' as Municipio union all
	select 'PR' as Estado, 'Pitangueiras' as Municipio union all
	select 'PR' as Estado, 'Planaltina do Paraná' as Municipio union all
	select 'PR' as Estado, 'Planalto' as Municipio union all
	select 'PR' as Estado, 'Ponta Grossa' as Municipio union all
	select 'PR' as Estado, 'Pontal do Paraná' as Municipio union all
	select 'PR' as Estado, 'Porecatu' as Municipio union all
	select 'PR' as Estado, 'Porto Amazonas' as Municipio union all
	select 'PR' as Estado, 'Porto Barreiro' as Municipio union all
	select 'PR' as Estado, 'Porto Rico' as Municipio union all
	select 'PR' as Estado, 'Porto Vitória' as Municipio union all
	select 'PR' as Estado, 'Prado Ferreira' as Municipio union all
	select 'PR' as Estado, 'Pranchita' as Municipio union all
	select 'PR' as Estado, 'Presidente Castelo Branco' as Municipio union all
	select 'PR' as Estado, 'Primeiro de Maio' as Municipio union all
	select 'PR' as Estado, 'Prudentópolis' as Municipio union all
	select 'PR' as Estado, 'Quarto Centenário' as Municipio union all
	select 'PR' as Estado, 'Quatiguá' as Municipio union all
	select 'PR' as Estado, 'Quatro Barras' as Municipio union all
	select 'PR' as Estado, 'Quatro Pontes' as Municipio union all
	select 'PR' as Estado, 'Quedas do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Querência do Norte' as Municipio union all
	select 'PR' as Estado, 'Quinta do Sol' as Municipio union all
	select 'PR' as Estado, 'Quitandinha' as Municipio union all
	select 'PR' as Estado, 'Ramilândia' as Municipio union all
	select 'PR' as Estado, 'Rancho Alegre' as Municipio union all
	select 'PR' as Estado, 'Rancho Alegre D''Oeste' as Municipio union all
	select 'PR' as Estado, 'Realeza' as Municipio union all
	select 'PR' as Estado, 'Rebouças' as Municipio union all
	select 'PR' as Estado, 'Renascença' as Municipio union all
	select 'PR' as Estado, 'Reserva' as Municipio union all
	select 'PR' as Estado, 'Reserva do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Ribeirão Claro' as Municipio union all
	select 'PR' as Estado, 'Ribeirão do Pinhal' as Municipio union all
	select 'PR' as Estado, 'Rio Azul' as Municipio union all
	select 'PR' as Estado, 'Rio Bom' as Municipio union all
	select 'PR' as Estado, 'Rio Bonito do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Rio Branco do Ivaí' as Municipio union all
	select 'PR' as Estado, 'Rio Branco do Sul' as Municipio union all
	select 'PR' as Estado, 'Rio Negro' as Municipio union all
	select 'PR' as Estado, 'Rolândia' as Municipio union all
	select 'PR' as Estado, 'Roncador' as Municipio union all
	select 'PR' as Estado, 'Rondon' as Municipio union all
	select 'PR' as Estado, 'Rosário do Ivaí' as Municipio union all
	select 'PR' as Estado, 'Sabáudia' as Municipio union all
	select 'PR' as Estado, 'Salgado Filho' as Municipio union all
	select 'PR' as Estado, 'Salto do Itararé' as Municipio union all
	select 'PR' as Estado, 'Salto do Lontra' as Municipio union all
	select 'PR' as Estado, 'Santa Amélia' as Municipio union all
	select 'PR' as Estado, 'Santa Cecília do Pavão' as Municipio union all
	select 'PR' as Estado, 'Santa Cruz de Monte Castelo' as Municipio union all
	select 'PR' as Estado, 'Santa Fé' as Municipio union all
	select 'PR' as Estado, 'Santa Helena' as Municipio union all
	select 'PR' as Estado, 'Santa Inês' as Municipio union all
	select 'PR' as Estado, 'Santa Isabel do Ivaí' as Municipio union all
	select 'PR' as Estado, 'Santa Izabel do Oeste' as Municipio union all
	select 'PR' as Estado, 'Santa Lúcia' as Municipio union all
	select 'PR' as Estado, 'Santa Maria do Oeste' as Municipio union all
	select 'PR' as Estado, 'Santa Mariana' as Municipio union all
	select 'PR' as Estado, 'Santa Mônica' as Municipio union all
	select 'PR' as Estado, 'Santa Tereza do Oeste' as Municipio union all
	select 'PR' as Estado, 'Santa Terezinha de Itaipu' as Municipio union all
	select 'PR' as Estado, 'Santana do Itararé' as Municipio union all
	select 'PR' as Estado, 'Santo Antônio da Platina' as Municipio union all
	select 'PR' as Estado, 'Santo Antônio do Caiuá' as Municipio union all
	select 'PR' as Estado, 'Santo Antônio do Paraíso' as Municipio union all
	select 'PR' as Estado, 'Santo Antônio do Sudoeste' as Municipio union all
	select 'PR' as Estado, 'Santo Inácio' as Municipio union all
	select 'PR' as Estado, 'São Carlos do Ivaí' as Municipio union all
	select 'PR' as Estado, 'São Jerônimo da Serra' as Municipio union all
	select 'PR' as Estado, 'São João' as Municipio union all
	select 'PR' as Estado, 'São João do Caiuá' as Municipio union all
	select 'PR' as Estado, 'São João do Ivaí' as Municipio union all
	select 'PR' as Estado, 'São João do Triunfo' as Municipio union all
	select 'PR' as Estado, 'São Jorge do Ivaí' as Municipio union all
	select 'PR' as Estado, 'São Jorge do Patrocínio' as Municipio union all
	select 'PR' as Estado, 'São Jorge d''Oeste' as Municipio union all
	select 'PR' as Estado, 'São José da Boa Vista' as Municipio union all
	select 'PR' as Estado, 'São José das Palmeiras' as Municipio union all
	select 'PR' as Estado, 'São José dos Pinhais' as Municipio union all
	select 'PR' as Estado, 'São Manoel do Paraná' as Municipio union all
	select 'PR' as Estado, 'São Mateus do Sul' as Municipio union all
	select 'PR' as Estado, 'São Miguel do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'São Pedro do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'São Pedro do Ivaí' as Municipio union all
	select 'PR' as Estado, 'São Pedro do Paraná' as Municipio union all
	select 'PR' as Estado, 'São Sebastião da Amoreira' as Municipio union all
	select 'PR' as Estado, 'São Tomé' as Municipio union all
	select 'PR' as Estado, 'Sapopema' as Municipio union all
	select 'PR' as Estado, 'Sarandi' as Municipio union all
	select 'PR' as Estado, 'Saudade do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Sengés' as Municipio union all
	select 'PR' as Estado, 'Serranópolis do Iguaçu' as Municipio union all
	select 'PR' as Estado, 'Sertaneja' as Municipio union all
	select 'PR' as Estado, 'Sertanópolis' as Municipio union all
	select 'PR' as Estado, 'Siqueira Campos' as Municipio union all
	select 'PR' as Estado, 'Sulina' as Municipio union all
	select 'PR' as Estado, 'Tamarana' as Municipio union all
	select 'PR' as Estado, 'Tamboara' as Municipio union all
	select 'PR' as Estado, 'Tapejara' as Municipio union all
	select 'PR' as Estado, 'Tapira' as Municipio union all
	select 'PR' as Estado, 'Teixeira Soares' as Municipio union all
	select 'PR' as Estado, 'Telêmaco Borba' as Municipio union all
	select 'PR' as Estado, 'Terra Boa' as Municipio union all
	select 'PR' as Estado, 'Terra Rica' as Municipio union all
	select 'PR' as Estado, 'Terra Roxa' as Municipio union all
	select 'PR' as Estado, 'Tibagi' as Municipio union all
	select 'PR' as Estado, 'Tijucas do Sul' as Municipio union all
	select 'PR' as Estado, 'Toledo' as Municipio union all
	select 'PR' as Estado, 'Tomazina' as Municipio union all
	select 'PR' as Estado, 'Três Barras do Paraná' as Municipio union all
	select 'PR' as Estado, 'Tunas do Paraná' as Municipio union all
	select 'PR' as Estado, 'Tuneiras do Oeste' as Municipio union all
	select 'PR' as Estado, 'Tupãssi' as Municipio union all
	select 'PR' as Estado, 'Turvo' as Municipio union all
	select 'PR' as Estado, 'Ubiratã' as Municipio union all
	select 'PR' as Estado, 'Umuarama' as Municipio union all
	select 'PR' as Estado, 'União da Vitória' as Municipio union all
	select 'PR' as Estado, 'Uniflor' as Municipio union all
	select 'PR' as Estado, 'Uraí' as Municipio union all
	select 'PR' as Estado, 'Ventania' as Municipio union all
	select 'PR' as Estado, 'Vera Cruz do Oeste' as Municipio union all
	select 'PR' as Estado, 'Verê' as Municipio union all
	select 'PR' as Estado, 'Virmond' as Municipio union all
	select 'PR' as Estado, 'Vitorino' as Municipio union all
	select 'PR' as Estado, 'Wenceslau Braz' as Municipio union all
	select 'PR' as Estado, 'Xambrê' as Municipio union all
	select 'SC' as Estado, 'Abdon Batista' as Municipio union all
	select 'SC' as Estado, 'Abelardo Luz' as Municipio union all
	select 'SC' as Estado, 'Agrolândia' as Municipio union all
	select 'SC' as Estado, 'Agronômica' as Municipio union all
	select 'SC' as Estado, 'Água Doce' as Municipio union all
	select 'SC' as Estado, 'Águas de Chapecó' as Municipio union all
	select 'SC' as Estado, 'Águas Frias' as Municipio union all
	select 'SC' as Estado, 'Águas Mornas' as Municipio union all
	select 'SC' as Estado, 'Alfredo Wagner' as Municipio union all
	select 'SC' as Estado, 'Alto Bela Vista' as Municipio union all
	select 'SC' as Estado, 'Anchieta' as Municipio union all
	select 'SC' as Estado, 'Angelina' as Municipio union all
	select 'SC' as Estado, 'Anita Garibaldi' as Municipio union all
	select 'SC' as Estado, 'Anitápolis' as Municipio union all
	select 'SC' as Estado, 'Antônio Carlos' as Municipio union all
	select 'SC' as Estado, 'Apiúna' as Municipio union all
	select 'SC' as Estado, 'Arabutã' as Municipio union all
	select 'SC' as Estado, 'Araquari' as Municipio union all
	select 'SC' as Estado, 'Araranguá' as Municipio union all
	select 'SC' as Estado, 'Armazém' as Municipio union all
	select 'SC' as Estado, 'Arroio Trinta' as Municipio union all
	select 'SC' as Estado, 'Arvoredo' as Municipio union all
	select 'SC' as Estado, 'Ascurra' as Municipio union all
	select 'SC' as Estado, 'Atalanta' as Municipio union all
	select 'SC' as Estado, 'Aurora' as Municipio union all
	select 'SC' as Estado, 'Balneário Arroio do Silva' as Municipio union all
	select 'SC' as Estado, 'Balneário Barra do Sul' as Municipio union all
	select 'SC' as Estado, 'Balneário Camboriú' as Municipio union all
	select 'SC' as Estado, 'Balneário Gaivota' as Municipio union all
	select 'SC' as Estado, 'Balneário Piçarras' as Municipio union all
	select 'SC' as Estado, 'Bandeirante' as Municipio union all
	select 'SC' as Estado, 'Barra Bonita' as Municipio union all
	select 'SC' as Estado, 'Barra Velha' as Municipio union all
	select 'SC' as Estado, 'Bela Vista do Toldo' as Municipio union all
	select 'SC' as Estado, 'Belmonte' as Municipio union all
	select 'SC' as Estado, 'Benedito Novo' as Municipio union all
	select 'SC' as Estado, 'Biguaçu' as Municipio union all
	select 'SC' as Estado, 'Blumenau' as Municipio union all
	select 'SC' as Estado, 'Bocaina do Sul' as Municipio union all
	select 'SC' as Estado, 'Bom Jardim da Serra' as Municipio union all
	select 'SC' as Estado, 'Bom Jesus' as Municipio union all
	select 'SC' as Estado, 'Bom Jesus do Oeste' as Municipio union all
	select 'SC' as Estado, 'Bom Retiro' as Municipio union all
	select 'SC' as Estado, 'Bombinhas' as Municipio union all
	select 'SC' as Estado, 'Botuverá' as Municipio union all
	select 'SC' as Estado, 'Braço do Norte' as Municipio union all
	select 'SC' as Estado, 'Braço do Trombudo' as Municipio union all
	select 'SC' as Estado, 'Brunópolis' as Municipio union all
	select 'SC' as Estado, 'Brusque' as Municipio union all
	select 'SC' as Estado, 'Caçador' as Municipio union all
	select 'SC' as Estado, 'Caibi' as Municipio union all
	select 'SC' as Estado, 'Calmon' as Municipio union all
	select 'SC' as Estado, 'Camboriú' as Municipio union all
	select 'SC' as Estado, 'Campo Alegre' as Municipio union all
	select 'SC' as Estado, 'Campo Belo do Sul' as Municipio union all
	select 'SC' as Estado, 'Campo Erê' as Municipio union all
	select 'SC' as Estado, 'Campos Novos' as Municipio union all
	select 'SC' as Estado, 'Canelinha' as Municipio union all
	select 'SC' as Estado, 'Canoinhas' as Municipio union all
	select 'SC' as Estado, 'Capão Alto' as Municipio union all
	select 'SC' as Estado, 'Capinzal' as Municipio union all
	select 'SC' as Estado, 'Capivari de Baixo' as Municipio union all
	select 'SC' as Estado, 'Catanduvas' as Municipio union all
	select 'SC' as Estado, 'Caxambu do Sul' as Municipio union all
	select 'SC' as Estado, 'Celso Ramos' as Municipio union all
	select 'SC' as Estado, 'Cerro Negro' as Municipio union all
	select 'SC' as Estado, 'Chapadão do Lageado' as Municipio union all
	select 'SC' as Estado, 'Chapecó' as Municipio union all
	select 'SC' as Estado, 'Cocal do Sul' as Municipio union all
	select 'SC' as Estado, 'Concórdia' as Municipio union all
	select 'SC' as Estado, 'Cordilheira Alta' as Municipio union all
	select 'SC' as Estado, 'Coronel Freitas' as Municipio union all
	select 'SC' as Estado, 'Coronel Martins' as Municipio union all
	select 'SC' as Estado, 'Correia Pinto' as Municipio union all
	select 'SC' as Estado, 'Corupá' as Municipio union all
	select 'SC' as Estado, 'Criciúma' as Municipio union all
	select 'SC' as Estado, 'Cunha Porã' as Municipio union all
	select 'SC' as Estado, 'Cunhataí' as Municipio union all
	select 'SC' as Estado, 'Curitibanos' as Municipio union all
	select 'SC' as Estado, 'Descanso' as Municipio union all
	select 'SC' as Estado, 'Dionísio Cerqueira' as Municipio union all
	select 'SC' as Estado, 'Dona Emma' as Municipio union all
	select 'SC' as Estado, 'Doutor Pedrinho' as Municipio union all
	select 'SC' as Estado, 'Entre Rios' as Municipio union all
	select 'SC' as Estado, 'Ermo' as Municipio union all
	select 'SC' as Estado, 'Erval Velho' as Municipio union all
	select 'SC' as Estado, 'Faxinal dos Guedes' as Municipio union all
	select 'SC' as Estado, 'Flor do Sertão' as Municipio union all
	select 'SC' as Estado, 'Florianópolis' as Municipio union all
	select 'SC' as Estado, 'Formosa do Sul' as Municipio union all
	select 'SC' as Estado, 'Forquilhinha' as Municipio union all
	select 'SC' as Estado, 'Fraiburgo' as Municipio union all
	select 'SC' as Estado, 'Frei Rogério' as Municipio union all
	select 'SC' as Estado, 'Galvão' as Municipio union all
	select 'SC' as Estado, 'Garopaba' as Municipio union all
	select 'SC' as Estado, 'Garuva' as Municipio union all
	select 'SC' as Estado, 'Gaspar' as Municipio union all
	select 'SC' as Estado, 'Governador Celso Ramos' as Municipio union all
	select 'SC' as Estado, 'Grão Pará' as Municipio union all
	select 'SC' as Estado, 'Gravatal' as Municipio union all
	select 'SC' as Estado, 'Guabiruba' as Municipio union all
	select 'SC' as Estado, 'Guaraciaba' as Municipio union all
	select 'SC' as Estado, 'Guaramirim' as Municipio union all
	select 'SC' as Estado, 'Guarujá do Sul' as Municipio union all
	select 'SC' as Estado, 'Guatambú' as Municipio union all
	select 'SC' as Estado, 'Herval d''Oeste' as Municipio union all
	select 'SC' as Estado, 'Ibiam' as Municipio union all
	select 'SC' as Estado, 'Ibicaré' as Municipio union all
	select 'SC' as Estado, 'Ibirama' as Municipio union all
	select 'SC' as Estado, 'Içara' as Municipio union all
	select 'SC' as Estado, 'Ilhota' as Municipio union all
	select 'SC' as Estado, 'Imaruí' as Municipio union all
	select 'SC' as Estado, 'Imbituba' as Municipio union all
	select 'SC' as Estado, 'Imbuia' as Municipio union all
	select 'SC' as Estado, 'Indaial' as Municipio union all
	select 'SC' as Estado, 'Iomerê' as Municipio union all
	select 'SC' as Estado, 'Ipira' as Municipio union all
	select 'SC' as Estado, 'Iporã do Oeste' as Municipio union all
	select 'SC' as Estado, 'Ipuaçu' as Municipio union all
	select 'SC' as Estado, 'Ipumirim' as Municipio union all
	select 'SC' as Estado, 'Iraceminha' as Municipio union all
	select 'SC' as Estado, 'Irani' as Municipio union all
	select 'SC' as Estado, 'Irati' as Municipio union all
	select 'SC' as Estado, 'Irineópolis' as Municipio union all
	select 'SC' as Estado, 'Itá' as Municipio union all
	select 'SC' as Estado, 'Itaiópolis' as Municipio union all
	select 'SC' as Estado, 'Itajaí' as Municipio union all
	select 'SC' as Estado, 'Itapema' as Municipio union all
	select 'SC' as Estado, 'Itapiranga' as Municipio union all
	select 'SC' as Estado, 'Itapoá' as Municipio union all
	select 'SC' as Estado, 'Ituporanga' as Municipio union all
	select 'SC' as Estado, 'Jaborá' as Municipio union all
	select 'SC' as Estado, 'Jacinto Machado' as Municipio union all
	select 'SC' as Estado, 'Jaguaruna' as Municipio union all
	select 'SC' as Estado, 'Jaraguá do Sul' as Municipio union all
	select 'SC' as Estado, 'Jardinópolis' as Municipio union all
	select 'SC' as Estado, 'Joaçaba' as Municipio union all
	select 'SC' as Estado, 'Joinville' as Municipio union all
	select 'SC' as Estado, 'José Boiteux' as Municipio union all
	select 'SC' as Estado, 'Jupiá' as Municipio union all
	select 'SC' as Estado, 'Lacerdópolis' as Municipio union all
	select 'SC' as Estado, 'Lages' as Municipio union all
	select 'SC' as Estado, 'Laguna' as Municipio union all
	select 'SC' as Estado, 'Lajeado Grande' as Municipio union all
	select 'SC' as Estado, 'Laurentino' as Municipio union all
	select 'SC' as Estado, 'Lauro Muller' as Municipio union all
	select 'SC' as Estado, 'Lebon Régis' as Municipio union all
	select 'SC' as Estado, 'Leoberto Leal' as Municipio union all
	select 'SC' as Estado, 'Lindóia do Sul' as Municipio union all
	select 'SC' as Estado, 'Lontras' as Municipio union all
	select 'SC' as Estado, 'Luiz Alves' as Municipio union all
	select 'SC' as Estado, 'Luzerna' as Municipio union all
	select 'SC' as Estado, 'Macieira' as Municipio union all
	select 'SC' as Estado, 'Mafra' as Municipio union all
	select 'SC' as Estado, 'Major Gercino' as Municipio union all
	select 'SC' as Estado, 'Major Vieira' as Municipio union all
	select 'SC' as Estado, 'Maracajá' as Municipio union all
	select 'SC' as Estado, 'Maravilha' as Municipio union all
	select 'SC' as Estado, 'Marema' as Municipio union all
	select 'SC' as Estado, 'Massaranduba' as Municipio union all
	select 'SC' as Estado, 'Matos Costa' as Municipio union all
	select 'SC' as Estado, 'Meleiro' as Municipio union all
	select 'SC' as Estado, 'Mirim Doce' as Municipio union all
	select 'SC' as Estado, 'Modelo' as Municipio union all
	select 'SC' as Estado, 'Mondaí' as Municipio union all
	select 'SC' as Estado, 'Monte Carlo' as Municipio union all
	select 'SC' as Estado, 'Monte Castelo' as Municipio union all
	select 'SC' as Estado, 'Morro da Fumaça' as Municipio union all
	select 'SC' as Estado, 'Morro Grande' as Municipio union all
	select 'SC' as Estado, 'Navegantes' as Municipio union all
	select 'SC' as Estado, 'Nova Erechim' as Municipio union all
	select 'SC' as Estado, 'Nova Itaberaba' as Municipio union all
	select 'SC' as Estado, 'Nova Trento' as Municipio union all
	select 'SC' as Estado, 'Nova Veneza' as Municipio union all
	select 'SC' as Estado, 'Novo Horizonte' as Municipio union all
	select 'SC' as Estado, 'Orleans' as Municipio union all
	select 'SC' as Estado, 'Otacílio Costa' as Municipio union all
	select 'SC' as Estado, 'Ouro' as Municipio union all
	select 'SC' as Estado, 'Ouro Verde' as Municipio union all
	select 'SC' as Estado, 'Paial' as Municipio union all
	select 'SC' as Estado, 'Painel' as Municipio union all
	select 'SC' as Estado, 'Palhoça' as Municipio union all
	select 'SC' as Estado, 'Palma Sola' as Municipio union all
	select 'SC' as Estado, 'Palmeira' as Municipio union all
	select 'SC' as Estado, 'Palmitos' as Municipio union all
	select 'SC' as Estado, 'Papanduva' as Municipio union all
	select 'SC' as Estado, 'Paraíso' as Municipio union all
	select 'SC' as Estado, 'Passo de Torres' as Municipio union all
	select 'SC' as Estado, 'Passos Maia' as Municipio union all
	select 'SC' as Estado, 'Paulo Lopes' as Municipio union all
	select 'SC' as Estado, 'Pedras Grandes' as Municipio union all
	select 'SC' as Estado, 'Penha' as Municipio union all
	select 'SC' as Estado, 'Peritiba' as Municipio union all
	select 'SC' as Estado, 'Petrolândia' as Municipio union all
	select 'SC' as Estado, 'Pinhalzinho' as Municipio union all
	select 'SC' as Estado, 'Pinheiro Preto' as Municipio union all
	select 'SC' as Estado, 'Piratuba' as Municipio union all
	select 'SC' as Estado, 'Planalto Alegre' as Municipio union all
	select 'SC' as Estado, 'Pomerode' as Municipio union all
	select 'SC' as Estado, 'Ponte Alta' as Municipio union all
	select 'SC' as Estado, 'Ponte Alta do Norte' as Municipio union all
	select 'SC' as Estado, 'Ponte Serrada' as Municipio union all
	select 'SC' as Estado, 'Porto Belo' as Municipio union all
	select 'SC' as Estado, 'Porto União' as Municipio union all
	select 'SC' as Estado, 'Pouso Redondo' as Municipio union all
	select 'SC' as Estado, 'Praia Grande' as Municipio union all
	select 'SC' as Estado, 'Presidente Castello Branco' as Municipio union all
	select 'SC' as Estado, 'Presidente Getúlio' as Municipio union all
	select 'SC' as Estado, 'Presidente Nereu' as Municipio union all
	select 'SC' as Estado, 'Princesa' as Municipio union all
	select 'SC' as Estado, 'Quilombo' as Municipio union all
	select 'SC' as Estado, 'Rancho Queimado' as Municipio union all
	select 'SC' as Estado, 'Rio das Antas' as Municipio union all
	select 'SC' as Estado, 'Rio do Campo' as Municipio union all
	select 'SC' as Estado, 'Rio do Oeste' as Municipio union all
	select 'SC' as Estado, 'Rio do Sul' as Municipio union all
	select 'SC' as Estado, 'Rio dos Cedros' as Municipio union all
	select 'SC' as Estado, 'Rio Fortuna' as Municipio union all
	select 'SC' as Estado, 'Rio Negrinho' as Municipio union all
	select 'SC' as Estado, 'Rio Rufino' as Municipio union all
	select 'SC' as Estado, 'Riqueza' as Municipio union all
	select 'SC' as Estado, 'Rodeio' as Municipio union all
	select 'SC' as Estado, 'Romelândia' as Municipio union all
	select 'SC' as Estado, 'Salete' as Municipio union all
	select 'SC' as Estado, 'Saltinho' as Municipio union all
	select 'SC' as Estado, 'Salto Veloso' as Municipio union all
	select 'SC' as Estado, 'Sangão' as Municipio union all
	select 'SC' as Estado, 'Santa Cecília' as Municipio union all
	select 'SC' as Estado, 'Santa Helena' as Municipio union all
	select 'SC' as Estado, 'Santa Rosa de Lima' as Municipio union all
	select 'SC' as Estado, 'Santa Rosa do Sul' as Municipio union all
	select 'SC' as Estado, 'Santa Terezinha' as Municipio union all
	select 'SC' as Estado, 'Santa Terezinha do Progresso' as Municipio union all
	select 'SC' as Estado, 'Santiago do Sul' as Municipio union all
	select 'SC' as Estado, 'Santo Amaro da Imperatriz' as Municipio union all
	select 'SC' as Estado, 'São Bento do Sul' as Municipio union all
	select 'SC' as Estado, 'São Bernardino' as Municipio union all
	select 'SC' as Estado, 'São Bonifácio' as Municipio union all
	select 'SC' as Estado, 'São Carlos' as Municipio union all
	select 'SC' as Estado, 'São Cristovão do Sul' as Municipio union all
	select 'SC' as Estado, 'São Domingos' as Municipio union all
	select 'SC' as Estado, 'São Francisco do Sul' as Municipio union all
	select 'SC' as Estado, 'São João Batista' as Municipio union all
	select 'SC' as Estado, 'São João do Itaperiú' as Municipio union all
	select 'SC' as Estado, 'São João do Oeste' as Municipio union all
	select 'SC' as Estado, 'São João do Sul' as Municipio union all
	select 'SC' as Estado, 'São Joaquim' as Municipio union all
	select 'SC' as Estado, 'São José' as Municipio union all
	select 'SC' as Estado, 'São José do Cedro' as Municipio union all
	select 'SC' as Estado, 'São José do Cerrito' as Municipio union all
	select 'SC' as Estado, 'São Lourenço do Oeste' as Municipio union all
	select 'SC' as Estado, 'São Ludgero' as Municipio union all
	select 'SC' as Estado, 'São Martinho' as Municipio union all
	select 'SC' as Estado, 'São Miguel da Boa Vista' as Municipio union all
	select 'SC' as Estado, 'São Miguel do Oeste' as Municipio union all
	select 'SC' as Estado, 'São Pedro de Alcântara' as Municipio union all
	select 'SC' as Estado, 'Saudades' as Municipio union all
	select 'SC' as Estado, 'Schroeder' as Municipio union all
	select 'SC' as Estado, 'Seara' as Municipio union all
	select 'SC' as Estado, 'Serra Alta' as Municipio union all
	select 'SC' as Estado, 'Siderópolis' as Municipio union all
	select 'SC' as Estado, 'Sombrio' as Municipio union all
	select 'SC' as Estado, 'Sul Brasil' as Municipio union all
	select 'SC' as Estado, 'Taió' as Municipio union all
	select 'SC' as Estado, 'Tangará' as Municipio union all
	select 'SC' as Estado, 'Tigrinhos' as Municipio union all
	select 'SC' as Estado, 'Tijucas' as Municipio union all
	select 'SC' as Estado, 'Timbé do Sul' as Municipio union all
	select 'SC' as Estado, 'Timbó' as Municipio union all
	select 'SC' as Estado, 'Timbó Grande' as Municipio union all
	select 'SC' as Estado, 'Três Barras' as Municipio union all
	select 'SC' as Estado, 'Treviso' as Municipio union all
	select 'SC' as Estado, 'Treze de Maio' as Municipio union all
	select 'SC' as Estado, 'Treze Tílias' as Municipio union all
	select 'SC' as Estado, 'Trombudo Central' as Municipio union all
	select 'SC' as Estado, 'Tubarão' as Municipio union all
	select 'SC' as Estado, 'Tunápolis' as Municipio union all
	select 'SC' as Estado, 'Turvo' as Municipio union all
	select 'SC' as Estado, 'União do Oeste' as Municipio union all
	select 'SC' as Estado, 'Urubici' as Municipio union all
	select 'SC' as Estado, 'Urupema' as Municipio union all
	select 'SC' as Estado, 'Urussanga' as Municipio union all
	select 'SC' as Estado, 'Vargeão' as Municipio union all
	select 'SC' as Estado, 'Vargem' as Municipio union all
	select 'SC' as Estado, 'Vargem Bonita' as Municipio union all
	select 'SC' as Estado, 'Vidal Ramos' as Municipio union all
	select 'SC' as Estado, 'Videira' as Municipio union all
	select 'SC' as Estado, 'Vitor Meireles' as Municipio union all
	select 'SC' as Estado, 'Witmarsum' as Municipio union all
	select 'SC' as Estado, 'Xanxerê' as Municipio union all
	select 'SC' as Estado, 'Xavantina' as Municipio union all
	select 'SC' as Estado, 'Xaxim' as Municipio union all
	select 'SC' as Estado, 'Zortéa' as Municipio union all
	select 'RS' as Estado, 'Aceguá' as Municipio union all
	select 'RS' as Estado, 'Água Santa' as Municipio union all
	select 'RS' as Estado, 'Agudo' as Municipio union all
	select 'RS' as Estado, 'Ajuricaba' as Municipio union all
	select 'RS' as Estado, 'Alecrim' as Municipio union all
	select 'RS' as Estado, 'Alegrete' as Municipio union all
	select 'RS' as Estado, 'Alegria' as Municipio union all
	select 'RS' as Estado, 'Almirante Tamandaré do Sul' as Municipio union all
	select 'RS' as Estado, 'Alpestre' as Municipio union all
	select 'RS' as Estado, 'Alto Alegre' as Municipio union all
	select 'RS' as Estado, 'Alto Feliz' as Municipio union all
	select 'RS' as Estado, 'Alvorada' as Municipio union all
	select 'RS' as Estado, 'Amaral Ferrador' as Municipio union all
	select 'RS' as Estado, 'Ametista do Sul' as Municipio union all
	select 'RS' as Estado, 'André da Rocha' as Municipio union all
	select 'RS' as Estado, 'Anta Gorda' as Municipio union all
	select 'RS' as Estado, 'Antônio Prado' as Municipio union all
	select 'RS' as Estado, 'Arambaré' as Municipio union all
	select 'RS' as Estado, 'Araricá' as Municipio union all
	select 'RS' as Estado, 'Aratiba' as Municipio union all
	select 'RS' as Estado, 'Arroio do Meio' as Municipio union all
	select 'RS' as Estado, 'Arroio do Padre' as Municipio union all
	select 'RS' as Estado, 'Arroio do Sal' as Municipio union all
	select 'RS' as Estado, 'Arroio do Tigre' as Municipio union all
	select 'RS' as Estado, 'Arroio dos Ratos' as Municipio union all
	select 'RS' as Estado, 'Arroio Grande' as Municipio union all
	select 'RS' as Estado, 'Arvorezinha' as Municipio union all
	select 'RS' as Estado, 'Augusto Pestana' as Municipio union all
	select 'RS' as Estado, 'Áurea' as Municipio union all
	select 'RS' as Estado, 'Bagé' as Municipio union all
	select 'RS' as Estado, 'Balneário Pinhal' as Municipio union all
	select 'RS' as Estado, 'Barão' as Municipio union all
	select 'RS' as Estado, 'Barão de Cotegipe' as Municipio union all
	select 'RS' as Estado, 'Barão do Triunfo' as Municipio union all
	select 'RS' as Estado, 'Barra do Guarita' as Municipio union all
	select 'RS' as Estado, 'Barra do Quaraí' as Municipio union all
	select 'RS' as Estado, 'Barra do Ribeiro' as Municipio union all
	select 'RS' as Estado, 'Barra do Rio Azul' as Municipio union all
	select 'RS' as Estado, 'Barra Funda' as Municipio union all
	select 'RS' as Estado, 'Barracão' as Municipio union all
	select 'RS' as Estado, 'Barros Cassal' as Municipio union all
	select 'RS' as Estado, 'Benjamin Constant do Sul' as Municipio union all
	select 'RS' as Estado, 'Bento Gonçalves' as Municipio union all
	select 'RS' as Estado, 'Boa Vista das Missões' as Municipio union all
	select 'RS' as Estado, 'Boa Vista do Buricá' as Municipio union all
	select 'RS' as Estado, 'Boa Vista do Cadeado' as Municipio union all
	select 'RS' as Estado, 'Boa Vista do Incra' as Municipio union all
	select 'RS' as Estado, 'Boa Vista do Sul' as Municipio union all
	select 'RS' as Estado, 'Bom Jesus' as Municipio union all
	select 'RS' as Estado, 'Bom Princípio' as Municipio union all
	select 'RS' as Estado, 'Bom Progresso' as Municipio union all
	select 'RS' as Estado, 'Bom Retiro do Sul' as Municipio union all
	select 'RS' as Estado, 'Boqueirão do Leão' as Municipio union all
	select 'RS' as Estado, 'Bossoroca' as Municipio union all
	select 'RS' as Estado, 'Bozano' as Municipio union all
	select 'RS' as Estado, 'Braga' as Municipio union all
	select 'RS' as Estado, 'Brochier' as Municipio union all
	select 'RS' as Estado, 'Butiá' as Municipio union all
	select 'RS' as Estado, 'Caçapava do Sul' as Municipio union all
	select 'RS' as Estado, 'Cacequi' as Municipio union all
	select 'RS' as Estado, 'Cachoeira do Sul' as Municipio union all
	select 'RS' as Estado, 'Cachoeirinha' as Municipio union all
	select 'RS' as Estado, 'Cacique Doble' as Municipio union all
	select 'RS' as Estado, 'Caibaté' as Municipio union all
	select 'RS' as Estado, 'Caiçara' as Municipio union all
	select 'RS' as Estado, 'Camaquã' as Municipio union all
	select 'RS' as Estado, 'Camargo' as Municipio union all
	select 'RS' as Estado, 'Cambará do Sul' as Municipio union all
	select 'RS' as Estado, 'Campestre da Serra' as Municipio union all
	select 'RS' as Estado, 'Campina das Missões' as Municipio union all
	select 'RS' as Estado, 'Campinas do Sul' as Municipio union all
	select 'RS' as Estado, 'Campo Bom' as Municipio union all
	select 'RS' as Estado, 'Campo Novo' as Municipio union all
	select 'RS' as Estado, 'Campos Borges' as Municipio union all
	select 'RS' as Estado, 'Candelária' as Municipio union all
	select 'RS' as Estado, 'Cândido Godói' as Municipio union all
	select 'RS' as Estado, 'Candiota' as Municipio union all
	select 'RS' as Estado, 'Canela' as Municipio union all
	select 'RS' as Estado, 'Canguçu' as Municipio union all
	select 'RS' as Estado, 'Canoas' as Municipio union all
	select 'RS' as Estado, 'Canudos do Vale' as Municipio union all
	select 'RS' as Estado, 'Capão Bonito do Sul' as Municipio union all
	select 'RS' as Estado, 'Capão da Canoa' as Municipio union all
	select 'RS' as Estado, 'Capão do Cipó' as Municipio union all
	select 'RS' as Estado, 'Capão do Leão' as Municipio union all
	select 'RS' as Estado, 'Capela de Santana' as Municipio union all
	select 'RS' as Estado, 'Capitão' as Municipio union all
	select 'RS' as Estado, 'Capivari do Sul' as Municipio union all
	select 'RS' as Estado, 'Caraá' as Municipio union all
	select 'RS' as Estado, 'Carazinho' as Municipio union all
	select 'RS' as Estado, 'Carlos Barbosa' as Municipio union all
	select 'RS' as Estado, 'Carlos Gomes' as Municipio union all
	select 'RS' as Estado, 'Casca' as Municipio union all
	select 'RS' as Estado, 'Caseiros' as Municipio union all
	select 'RS' as Estado, 'Catuípe' as Municipio union all
	select 'RS' as Estado, 'Caxias do Sul' as Municipio union all
	select 'RS' as Estado, 'Centenário' as Municipio union all
	select 'RS' as Estado, 'Cerrito' as Municipio union all
	select 'RS' as Estado, 'Cerro Branco' as Municipio union all
	select 'RS' as Estado, 'Cerro Grande' as Municipio union all
	select 'RS' as Estado, 'Cerro Grande do Sul' as Municipio union all
	select 'RS' as Estado, 'Cerro Largo' as Municipio union all
	select 'RS' as Estado, 'Chapada' as Municipio union all
	select 'RS' as Estado, 'Charqueadas' as Municipio union all
	select 'RS' as Estado, 'Charrua' as Municipio union all
	select 'RS' as Estado, 'Chiapetta' as Municipio union all
	select 'RS' as Estado, 'Chuí' as Municipio union all
	select 'RS' as Estado, 'Chuvisca' as Municipio union all
	select 'RS' as Estado, 'Cidreira' as Municipio union all
	select 'RS' as Estado, 'Ciríaco' as Municipio union all
	select 'RS' as Estado, 'Colinas' as Municipio union all
	select 'RS' as Estado, 'Colorado' as Municipio union all
	select 'RS' as Estado, 'Condor' as Municipio union all
	select 'RS' as Estado, 'Constantina' as Municipio union all
	select 'RS' as Estado, 'Coqueiro Baixo' as Municipio union all
	select 'RS' as Estado, 'Coqueiros do Sul' as Municipio union all
	select 'RS' as Estado, 'Coronel Barros' as Municipio union all
	select 'RS' as Estado, 'Coronel Bicaco' as Municipio union all
	select 'RS' as Estado, 'Coronel Pilar' as Municipio union all
	select 'RS' as Estado, 'Cotiporã' as Municipio union all
	select 'RS' as Estado, 'Coxilha' as Municipio union all
	select 'RS' as Estado, 'Crissiumal' as Municipio union all
	select 'RS' as Estado, 'Cristal' as Municipio union all
	select 'RS' as Estado, 'Cristal do Sul' as Municipio union all
	select 'RS' as Estado, 'Cruz Alta' as Municipio union all
	select 'RS' as Estado, 'Cruzaltense' as Municipio union all
	select 'RS' as Estado, 'Cruzeiro do Sul' as Municipio union all
	select 'RS' as Estado, 'David Canabarro' as Municipio union all
	select 'RS' as Estado, 'Derrubadas' as Municipio union all
	select 'RS' as Estado, 'Dezesseis de Novembro' as Municipio union all
	select 'RS' as Estado, 'Dilermando de Aguiar' as Municipio union all
	select 'RS' as Estado, 'Dois Irmãos' as Municipio union all
	select 'RS' as Estado, 'Dois Irmãos das Missões' as Municipio union all
	select 'RS' as Estado, 'Dois Lajeados' as Municipio union all
	select 'RS' as Estado, 'Dom Feliciano' as Municipio union all
	select 'RS' as Estado, 'Dom Pedrito' as Municipio union all
	select 'RS' as Estado, 'Dom Pedro de Alcântara' as Municipio union all
	select 'RS' as Estado, 'Dona Francisca' as Municipio union all
	select 'RS' as Estado, 'Doutor Maurício Cardoso' as Municipio union all
	select 'RS' as Estado, 'Doutor Ricardo' as Municipio union all
	select 'RS' as Estado, 'Eldorado do Sul' as Municipio union all
	select 'RS' as Estado, 'Encantado' as Municipio union all
	select 'RS' as Estado, 'Encruzilhada do Sul' as Municipio union all
	select 'RS' as Estado, 'Engenho Velho' as Municipio union all
	select 'RS' as Estado, 'Entre Rios do Sul' as Municipio union all
	select 'RS' as Estado, 'Entre-Ijuís' as Municipio union all
	select 'RS' as Estado, 'Erebango' as Municipio union all
	select 'RS' as Estado, 'Erechim' as Municipio union all
	select 'RS' as Estado, 'Ernestina' as Municipio union all
	select 'RS' as Estado, 'Erval Grande' as Municipio union all
	select 'RS' as Estado, 'Erval Seco' as Municipio union all
	select 'RS' as Estado, 'Esmeralda' as Municipio union all
	select 'RS' as Estado, 'Esperança do Sul' as Municipio union all
	select 'RS' as Estado, 'Espumoso' as Municipio union all
	select 'RS' as Estado, 'Estação' as Municipio union all
	select 'RS' as Estado, 'Estância Velha' as Municipio union all
	select 'RS' as Estado, 'Esteio' as Municipio union all
	select 'RS' as Estado, 'Estrela' as Municipio union all
	select 'RS' as Estado, 'Estrela Velha' as Municipio union all
	select 'RS' as Estado, 'Eugênio de Castro' as Municipio union all
	select 'RS' as Estado, 'Fagundes Varela' as Municipio union all
	select 'RS' as Estado, 'Farroupilha' as Municipio union all
	select 'RS' as Estado, 'Faxinal do Soturno' as Municipio union all
	select 'RS' as Estado, 'Faxinalzinho' as Municipio union all
	select 'RS' as Estado, 'Fazenda Vilanova' as Municipio union all
	select 'RS' as Estado, 'Feliz' as Municipio union all
	select 'RS' as Estado, 'Flores da Cunha' as Municipio union all
	select 'RS' as Estado, 'Floriano Peixoto' as Municipio union all
	select 'RS' as Estado, 'Fontoura Xavier' as Municipio union all
	select 'RS' as Estado, 'Formigueiro' as Municipio union all
	select 'RS' as Estado, 'Forquetinha' as Municipio union all
	select 'RS' as Estado, 'Fortaleza dos Valos' as Municipio union all
	select 'RS' as Estado, 'Frederico Westphalen' as Municipio union all
	select 'RS' as Estado, 'Garibaldi' as Municipio union all
	select 'RS' as Estado, 'Garruchos' as Municipio union all
	select 'RS' as Estado, 'Gaurama' as Municipio union all
	select 'RS' as Estado, 'General Câmara' as Municipio union all
	select 'RS' as Estado, 'Gentil' as Municipio union all
	select 'RS' as Estado, 'Getúlio Vargas' as Municipio union all
	select 'RS' as Estado, 'Giruá' as Municipio union all
	select 'RS' as Estado, 'Glorinha' as Municipio union all
	select 'RS' as Estado, 'Gramado' as Municipio union all
	select 'RS' as Estado, 'Gramado dos Loureiros' as Municipio union all
	select 'RS' as Estado, 'Gramado Xavier' as Municipio union all
	select 'RS' as Estado, 'Gravataí' as Municipio union all
	select 'RS' as Estado, 'Guabiju' as Municipio union all
	select 'RS' as Estado, 'Guaíba' as Municipio union all
	select 'RS' as Estado, 'Guaporé' as Municipio union all
	select 'RS' as Estado, 'Guarani das Missões' as Municipio union all
	select 'RS' as Estado, 'Harmonia' as Municipio union all
	select 'RS' as Estado, 'Herval' as Municipio union all
	select 'RS' as Estado, 'Herveiras' as Municipio union all
	select 'RS' as Estado, 'Horizontina' as Municipio union all
	select 'RS' as Estado, 'Hulha Negra' as Municipio union all
	select 'RS' as Estado, 'Humaitá' as Municipio union all
	select 'RS' as Estado, 'Ibarama' as Municipio union all
	select 'RS' as Estado, 'Ibiaçá' as Municipio union all
	select 'RS' as Estado, 'Ibiraiaras' as Municipio union all
	select 'RS' as Estado, 'Ibirapuitã' as Municipio union all
	select 'RS' as Estado, 'Ibirubá' as Municipio union all
	select 'RS' as Estado, 'Igrejinha' as Municipio union all
	select 'RS' as Estado, 'Ijuí' as Municipio union all
	select 'RS' as Estado, 'Ilópolis' as Municipio union all
	select 'RS' as Estado, 'Imbé' as Municipio union all
	select 'RS' as Estado, 'Imigrante' as Municipio union all
	select 'RS' as Estado, 'Independência' as Municipio union all
	select 'RS' as Estado, 'Inhacorá' as Municipio union all
	select 'RS' as Estado, 'Ipê' as Municipio union all
	select 'RS' as Estado, 'Ipiranga do Sul' as Municipio union all
	select 'RS' as Estado, 'Iraí' as Municipio union all
	select 'RS' as Estado, 'Itaara' as Municipio union all
	select 'RS' as Estado, 'Itacurubi' as Municipio union all
	select 'RS' as Estado, 'Itapuca' as Municipio union all
	select 'RS' as Estado, 'Itaqui' as Municipio union all
	select 'RS' as Estado, 'Itati' as Municipio union all
	select 'RS' as Estado, 'Itatiba do Sul' as Municipio union all
	select 'RS' as Estado, 'Ivorá' as Municipio union all
	select 'RS' as Estado, 'Ivoti' as Municipio union all
	select 'RS' as Estado, 'Jaboticaba' as Municipio union all
	select 'RS' as Estado, 'Jacuizinho' as Municipio union all
	select 'RS' as Estado, 'Jacutinga' as Municipio union all
	select 'RS' as Estado, 'Jaguarão' as Municipio union all
	select 'RS' as Estado, 'Jaguari' as Municipio union all
	select 'RS' as Estado, 'Jaquirana' as Municipio union all
	select 'RS' as Estado, 'Jari' as Municipio union all
	select 'RS' as Estado, 'Jóia' as Municipio union all
	select 'RS' as Estado, 'Júlio de Castilhos' as Municipio union all
	select 'RS' as Estado, 'Lagoa Bonita do Sul' as Municipio union all
	select 'RS' as Estado, 'Lagoa dos Três Cantos' as Municipio union all
	select 'RS' as Estado, 'Lagoa Vermelha' as Municipio union all
	select 'RS' as Estado, 'Lagoão' as Municipio union all
	select 'RS' as Estado, 'Lajeado' as Municipio union all
	select 'RS' as Estado, 'Lajeado do Bugre' as Municipio union all
	select 'RS' as Estado, 'Lavras do Sul' as Municipio union all
	select 'RS' as Estado, 'Liberato Salzano' as Municipio union all
	select 'RS' as Estado, 'Lindolfo Collor' as Municipio union all
	select 'RS' as Estado, 'Linha Nova' as Municipio union all
	select 'RS' as Estado, 'Maçambara' as Municipio union all
	select 'RS' as Estado, 'Machadinho' as Municipio union all
	select 'RS' as Estado, 'Mampituba' as Municipio union all
	select 'RS' as Estado, 'Manoel Viana' as Municipio union all
	select 'RS' as Estado, 'Maquiné' as Municipio union all
	select 'RS' as Estado, 'Maratá' as Municipio union all
	select 'RS' as Estado, 'Marau' as Municipio union all
	select 'RS' as Estado, 'Marcelino Ramos' as Municipio union all
	select 'RS' as Estado, 'Mariana Pimentel' as Municipio union all
	select 'RS' as Estado, 'Mariano Moro' as Municipio union all
	select 'RS' as Estado, 'Marques de Souza' as Municipio union all
	select 'RS' as Estado, 'Mata' as Municipio union all
	select 'RS' as Estado, 'Mato Castelhano' as Municipio union all
	select 'RS' as Estado, 'Mato Leitão' as Municipio union all
	select 'RS' as Estado, 'Mato Queimado' as Municipio union all
	select 'RS' as Estado, 'Maximiliano de Almeida' as Municipio union all
	select 'RS' as Estado, 'Minas do Leão' as Municipio union all
	select 'RS' as Estado, 'Miraguaí' as Municipio union all
	select 'RS' as Estado, 'Montauri' as Municipio union all
	select 'RS' as Estado, 'Monte Alegre dos Campos' as Municipio union all
	select 'RS' as Estado, 'Monte Belo do Sul' as Municipio union all
	select 'RS' as Estado, 'Montenegro' as Municipio union all
	select 'RS' as Estado, 'Mormaço' as Municipio union all
	select 'RS' as Estado, 'Morrinhos do Sul' as Municipio union all
	select 'RS' as Estado, 'Morro Redondo' as Municipio union all
	select 'RS' as Estado, 'Morro Reuter' as Municipio union all
	select 'RS' as Estado, 'Mostardas' as Municipio union all
	select 'RS' as Estado, 'Muçum' as Municipio union all
	select 'RS' as Estado, 'Muitos Capões' as Municipio union all
	select 'RS' as Estado, 'Muliterno' as Municipio union all
	select 'RS' as Estado, 'Não-Me-Toque' as Municipio union all
	select 'RS' as Estado, 'Nicolau Vergueiro' as Municipio union all
	select 'RS' as Estado, 'Nonoai' as Municipio union all
	select 'RS' as Estado, 'Nova Alvorada' as Municipio union all
	select 'RS' as Estado, 'Nova Araçá' as Municipio union all
	select 'RS' as Estado, 'Nova Bassano' as Municipio union all
	select 'RS' as Estado, 'Nova Boa Vista' as Municipio union all
	select 'RS' as Estado, 'Nova Bréscia' as Municipio union all
	select 'RS' as Estado, 'Nova Candelária' as Municipio union all
	select 'RS' as Estado, 'Nova Esperança do Sul' as Municipio union all
	select 'RS' as Estado, 'Nova Hartz' as Municipio union all
	select 'RS' as Estado, 'Nova Pádua' as Municipio union all
	select 'RS' as Estado, 'Nova Palma' as Municipio union all
	select 'RS' as Estado, 'Nova Petrópolis' as Municipio union all
	select 'RS' as Estado, 'Nova Prata' as Municipio union all
	select 'RS' as Estado, 'Nova Ramada' as Municipio union all
	select 'RS' as Estado, 'Nova Roma do Sul' as Municipio union all
	select 'RS' as Estado, 'Nova Santa Rita' as Municipio union all
	select 'RS' as Estado, 'Novo Barreiro' as Municipio union all
	select 'RS' as Estado, 'Novo Cabrais' as Municipio union all
	select 'RS' as Estado, 'Novo Hamburgo' as Municipio union all
	select 'RS' as Estado, 'Novo Machado' as Municipio union all
	select 'RS' as Estado, 'Novo Tiradentes' as Municipio union all
	select 'RS' as Estado, 'Novo Xingu' as Municipio union all
	select 'RS' as Estado, 'Osório' as Municipio union all
	select 'RS' as Estado, 'Paim Filho' as Municipio union all
	select 'RS' as Estado, 'Palmares do Sul' as Municipio union all
	select 'RS' as Estado, 'Palmeira das Missões' as Municipio union all
	select 'RS' as Estado, 'Palmitinho' as Municipio union all
	select 'RS' as Estado, 'Panambi' as Municipio union all
	select 'RS' as Estado, 'Pantano Grande' as Municipio union all
	select 'RS' as Estado, 'Paraí' as Municipio union all
	select 'RS' as Estado, 'Paraíso do Sul' as Municipio union all
	select 'RS' as Estado, 'Pareci Novo' as Municipio union all
	select 'RS' as Estado, 'Parobé' as Municipio union all
	select 'RS' as Estado, 'Passa Sete' as Municipio union all
	select 'RS' as Estado, 'Passo do Sobrado' as Municipio union all
	select 'RS' as Estado, 'Passo Fundo' as Municipio union all
	select 'RS' as Estado, 'Paulo Bento' as Municipio union all
	select 'RS' as Estado, 'Paverama' as Municipio union all
	select 'RS' as Estado, 'Pedras Altas' as Municipio union all
	select 'RS' as Estado, 'Pedro Osório' as Municipio union all
	select 'RS' as Estado, 'Pejuçara' as Municipio union all
	select 'RS' as Estado, 'Pelotas' as Municipio union all
	select 'RS' as Estado, 'Picada Café' as Municipio union all
	select 'RS' as Estado, 'Pinhal' as Municipio union all
	select 'RS' as Estado, 'Pinhal da Serra' as Municipio union all
	select 'RS' as Estado, 'Pinhal Grande' as Municipio union all
	select 'RS' as Estado, 'Pinheirinho do Vale' as Municipio union all
	select 'RS' as Estado, 'Pinheiro Machado' as Municipio union all
	select 'RS' as Estado, 'Pirapó' as Municipio union all
	select 'RS' as Estado, 'Piratini' as Municipio union all
	select 'RS' as Estado, 'Planalto' as Municipio union all
	select 'RS' as Estado, 'Poço das Antas' as Municipio union all
	select 'RS' as Estado, 'Pontão' as Municipio union all
	select 'RS' as Estado, 'Ponte Preta' as Municipio union all
	select 'RS' as Estado, 'Portão' as Municipio union all
	select 'RS' as Estado, 'Porto Alegre' as Municipio union all
	select 'RS' as Estado, 'Porto Lucena' as Municipio union all
	select 'RS' as Estado, 'Porto Mauá' as Municipio union all
	select 'RS' as Estado, 'Porto Vera Cruz' as Municipio union all
	select 'RS' as Estado, 'Porto Xavier' as Municipio union all
	select 'RS' as Estado, 'Pouso Novo' as Municipio union all
	select 'RS' as Estado, 'Presidente Lucena' as Municipio union all
	select 'RS' as Estado, 'Progresso' as Municipio union all
	select 'RS' as Estado, 'Protásio Alves' as Municipio union all
	select 'RS' as Estado, 'Putinga' as Municipio union all
	select 'RS' as Estado, 'Quaraí' as Municipio union all
	select 'RS' as Estado, 'Quatro Irmãos' as Municipio union all
	select 'RS' as Estado, 'Quevedos' as Municipio union all
	select 'RS' as Estado, 'Quinze de Novembro' as Municipio union all
	select 'RS' as Estado, 'Redentora' as Municipio union all
	select 'RS' as Estado, 'Relvado' as Municipio union all
	select 'RS' as Estado, 'Restinga Seca' as Municipio union all
	select 'RS' as Estado, 'Rio dos Índios' as Municipio union all
	select 'RS' as Estado, 'Rio Grande' as Municipio union all
	select 'RS' as Estado, 'Rio Pardo' as Municipio union all
	select 'RS' as Estado, 'Riozinho' as Municipio union all
	select 'RS' as Estado, 'Roca Sales' as Municipio union all
	select 'RS' as Estado, 'Rodeio Bonito' as Municipio union all
	select 'RS' as Estado, 'Rolador' as Municipio union all
	select 'RS' as Estado, 'Rolante' as Municipio union all
	select 'RS' as Estado, 'Ronda Alta' as Municipio union all
	select 'RS' as Estado, 'Rondinha' as Municipio union all
	select 'RS' as Estado, 'Roque Gonzales' as Municipio union all
	select 'RS' as Estado, 'Rosário do Sul' as Municipio union all
	select 'RS' as Estado, 'Sagrada Família' as Municipio union all
	select 'RS' as Estado, 'Saldanha Marinho' as Municipio union all
	select 'RS' as Estado, 'Salto do Jacuí' as Municipio union all
	select 'RS' as Estado, 'Salvador das Missões' as Municipio union all
	select 'RS' as Estado, 'Salvador do Sul' as Municipio union all
	select 'RS' as Estado, 'Sananduva' as Municipio union all
	select 'RS' as Estado, 'Santa Bárbara do Sul' as Municipio union all
	select 'RS' as Estado, 'Santa Cecília do Sul' as Municipio union all
	select 'RS' as Estado, 'Santa Clara do Sul' as Municipio union all
	select 'RS' as Estado, 'Santa Cruz do Sul' as Municipio union all
	select 'RS' as Estado, 'Santa Margarida do Sul' as Municipio union all
	select 'RS' as Estado, 'Santa Maria' as Municipio union all
	select 'RS' as Estado, 'Santa Maria do Herval' as Municipio union all
	select 'RS' as Estado, 'Santa Rosa' as Municipio union all
	select 'RS' as Estado, 'Santa Tereza' as Municipio union all
	select 'RS' as Estado, 'Santa Vitória do Palmar' as Municipio union all
	select 'RS' as Estado, 'Santana da Boa Vista' as Municipio union all
	select 'RS' as Estado, 'Santana do Livramento' as Municipio union all
	select 'RS' as Estado, 'Santiago' as Municipio union all
	select 'RS' as Estado, 'Santo Ângelo' as Municipio union all
	select 'RS' as Estado, 'Santo Antônio da Patrulha' as Municipio union all
	select 'RS' as Estado, 'Santo Antônio das Missões' as Municipio union all
	select 'RS' as Estado, 'Santo Antônio do Palma' as Municipio union all
	select 'RS' as Estado, 'Santo Antônio do Planalto' as Municipio union all
	select 'RS' as Estado, 'Santo Augusto' as Municipio union all
	select 'RS' as Estado, 'Santo Cristo' as Municipio union all
	select 'RS' as Estado, 'Santo Expedito do Sul' as Municipio union all
	select 'RS' as Estado, 'São Borja' as Municipio union all
	select 'RS' as Estado, 'São Domingos do Sul' as Municipio union all
	select 'RS' as Estado, 'São Francisco de Assis' as Municipio union all
	select 'RS' as Estado, 'São Francisco de Paula' as Municipio union all
	select 'RS' as Estado, 'São Gabriel' as Municipio union all
	select 'RS' as Estado, 'São Jerônimo' as Municipio union all
	select 'RS' as Estado, 'São João da Urtiga' as Municipio union all
	select 'RS' as Estado, 'São João do Polêsine' as Municipio union all
	select 'RS' as Estado, 'São Jorge' as Municipio union all
	select 'RS' as Estado, 'São José das Missões' as Municipio union all
	select 'RS' as Estado, 'São José do Herval' as Municipio union all
	select 'RS' as Estado, 'São José do Hortêncio' as Municipio union all
	select 'RS' as Estado, 'São José do Inhacorá' as Municipio union all
	select 'RS' as Estado, 'São José do Norte' as Municipio union all
	select 'RS' as Estado, 'São José do Ouro' as Municipio union all
	select 'RS' as Estado, 'São José do Sul' as Municipio union all
	select 'RS' as Estado, 'São José dos Ausentes' as Municipio union all
	select 'RS' as Estado, 'São Leopoldo' as Municipio union all
	select 'RS' as Estado, 'São Lourenço do Sul' as Municipio union all
	select 'RS' as Estado, 'São Luiz Gonzaga' as Municipio union all
	select 'RS' as Estado, 'São Marcos' as Municipio union all
	select 'RS' as Estado, 'São Martinho' as Municipio union all
	select 'RS' as Estado, 'São Martinho da Serra' as Municipio union all
	select 'RS' as Estado, 'São Miguel das Missões' as Municipio union all
	select 'RS' as Estado, 'São Nicolau' as Municipio union all
	select 'RS' as Estado, 'São Paulo das Missões' as Municipio union all
	select 'RS' as Estado, 'São Pedro da Serra' as Municipio union all
	select 'RS' as Estado, 'São Pedro das Missões' as Municipio union all
	select 'RS' as Estado, 'São Pedro do Butiá' as Municipio union all
	select 'RS' as Estado, 'São Pedro do Sul' as Municipio union all
	select 'RS' as Estado, 'São Sebastião do Caí' as Municipio union all
	select 'RS' as Estado, 'São Sepé' as Municipio union all
	select 'RS' as Estado, 'São Valentim' as Municipio union all
	select 'RS' as Estado, 'São Valentim do Sul' as Municipio union all
	select 'RS' as Estado, 'São Valério do Sul' as Municipio union all
	select 'RS' as Estado, 'São Vendelino' as Municipio union all
	select 'RS' as Estado, 'São Vicente do Sul' as Municipio union all
	select 'RS' as Estado, 'Sapiranga' as Municipio union all
	select 'RS' as Estado, 'Sapucaia do Sul' as Municipio union all
	select 'RS' as Estado, 'Sarandi' as Municipio union all
	select 'RS' as Estado, 'Seberi' as Municipio union all
	select 'RS' as Estado, 'Sede Nova' as Municipio union all
	select 'RS' as Estado, 'Segredo' as Municipio union all
	select 'RS' as Estado, 'Selbach' as Municipio union all
	select 'RS' as Estado, 'Senador Salgado Filho' as Municipio union all
	select 'RS' as Estado, 'Sentinela do Sul' as Municipio union all
	select 'RS' as Estado, 'Serafina Corrêa' as Municipio union all
	select 'RS' as Estado, 'Sério' as Municipio union all
	select 'RS' as Estado, 'Sertão' as Municipio union all
	select 'RS' as Estado, 'Sertão Santana' as Municipio union all
	select 'RS' as Estado, 'Sete de Setembro' as Municipio union all
	select 'RS' as Estado, 'Severiano de Almeida' as Municipio union all
	select 'RS' as Estado, 'Silveira Martins' as Municipio union all
	select 'RS' as Estado, 'Sinimbu' as Municipio union all
	select 'RS' as Estado, 'Sobradinho' as Municipio union all
	select 'RS' as Estado, 'Soledade' as Municipio union all
	select 'RS' as Estado, 'Tabaí' as Municipio union all
	select 'RS' as Estado, 'Tapejara' as Municipio union all
	select 'RS' as Estado, 'Tapera' as Municipio union all
	select 'RS' as Estado, 'Tapes' as Municipio union all
	select 'RS' as Estado, 'Taquara' as Municipio union all
	select 'RS' as Estado, 'Taquari' as Municipio union all
	select 'RS' as Estado, 'Taquaruçu do Sul' as Municipio union all
	select 'RS' as Estado, 'Tavares' as Municipio union all
	select 'RS' as Estado, 'Tenente Portela' as Municipio union all
	select 'RS' as Estado, 'Terra de Areia' as Municipio union all
	select 'RS' as Estado, 'Teutônia' as Municipio union all
	select 'RS' as Estado, 'Tio Hugo' as Municipio union all
	select 'RS' as Estado, 'Tiradentes do Sul' as Municipio union all
	select 'RS' as Estado, 'Toropi' as Municipio union all
	select 'RS' as Estado, 'Torres' as Municipio union all
	select 'RS' as Estado, 'Tramandaí' as Municipio union all
	select 'RS' as Estado, 'Travesseiro' as Municipio union all
	select 'RS' as Estado, 'Três Arroios' as Municipio union all
	select 'RS' as Estado, 'Três Cachoeiras' as Municipio union all
	select 'RS' as Estado, 'Três Coroas' as Municipio union all
	select 'RS' as Estado, 'Três de Maio' as Municipio union all
	select 'RS' as Estado, 'Três Forquilhas' as Municipio union all
	select 'RS' as Estado, 'Três Palmeiras' as Municipio union all
	select 'RS' as Estado, 'Três Passos' as Municipio union all
	select 'RS' as Estado, 'Trindade do Sul' as Municipio union all
	select 'RS' as Estado, 'Triunfo' as Municipio union all
	select 'RS' as Estado, 'Tucunduva' as Municipio union all
	select 'RS' as Estado, 'Tunas' as Municipio union all
	select 'RS' as Estado, 'Tupanci do Sul' as Municipio union all
	select 'RS' as Estado, 'Tupanciretã' as Municipio union all
	select 'RS' as Estado, 'Tupandi' as Municipio union all
	select 'RS' as Estado, 'Tuparendi' as Municipio union all
	select 'RS' as Estado, 'Turuçu' as Municipio union all
	select 'RS' as Estado, 'Ubiretama' as Municipio union all
	select 'RS' as Estado, 'União da Serra' as Municipio union all
	select 'RS' as Estado, 'Unistalda' as Municipio union all
	select 'RS' as Estado, 'Uruguaiana' as Municipio union all
	select 'RS' as Estado, 'Vacaria' as Municipio union all
	select 'RS' as Estado, 'Vale do Sol' as Municipio union all
	select 'RS' as Estado, 'Vale Real' as Municipio union all
	select 'RS' as Estado, 'Vale Verde' as Municipio union all
	select 'RS' as Estado, 'Vanini' as Municipio union all
	select 'RS' as Estado, 'Venâncio Aires' as Municipio union all
	select 'RS' as Estado, 'Vera Cruz' as Municipio union all
	select 'RS' as Estado, 'Veranópolis' as Municipio union all
	select 'RS' as Estado, 'Vespasiano Correa' as Municipio union all
	select 'RS' as Estado, 'Viadutos' as Municipio union all
	select 'RS' as Estado, 'Viamão' as Municipio union all
	select 'RS' as Estado, 'Vicente Dutra' as Municipio union all
	select 'RS' as Estado, 'Victor Graeff' as Municipio union all
	select 'RS' as Estado, 'Vila Flores' as Municipio union all
	select 'RS' as Estado, 'Vila Lângaro' as Municipio union all
	select 'RS' as Estado, 'Vila Maria' as Municipio union all
	select 'RS' as Estado, 'Vila Nova do Sul' as Municipio union all
	select 'RS' as Estado, 'Vista Alegre' as Municipio union all
	select 'RS' as Estado, 'Vista Alegre do Prata' as Municipio union all
	select 'RS' as Estado, 'Vista Gaúcha' as Municipio union all
	select 'RS' as Estado, 'Vitória das Missões' as Municipio union all
	select 'RS' as Estado, 'Westfalia' as Municipio union all
	select 'RS' as Estado, 'Xangri-lá' as Municipio union all
	select 'MS' as Estado, 'Água Clara' as Municipio union all
	select 'MS' as Estado, 'Alcinópolis' as Municipio union all
	select 'MS' as Estado, 'Amambaí' as Municipio union all
	select 'MS' as Estado, 'Anastácio' as Municipio union all
	select 'MS' as Estado, 'Anaurilândia' as Municipio union all
	select 'MS' as Estado, 'Angélica' as Municipio union all
	select 'MS' as Estado, 'Antônio João' as Municipio union all
	select 'MS' as Estado, 'Aparecida do Taboado' as Municipio union all
	select 'MS' as Estado, 'Aquidauana' as Municipio union all
	select 'MS' as Estado, 'Aral Moreira' as Municipio union all
	select 'MS' as Estado, 'Bandeirantes' as Municipio union all
	select 'MS' as Estado, 'Bataguassu' as Municipio union all
	select 'MS' as Estado, 'Batayporã' as Municipio union all
	select 'MS' as Estado, 'Bela Vista' as Municipio union all
	select 'MS' as Estado, 'Bodoquena' as Municipio union all
	select 'MS' as Estado, 'Bonito' as Municipio union all
	select 'MS' as Estado, 'Brasilândia' as Municipio union all
	select 'MS' as Estado, 'Caarapó' as Municipio union all
	select 'MS' as Estado, 'Camapuã' as Municipio union all
	select 'MS' as Estado, 'Campo Grande' as Municipio union all
	select 'MS' as Estado, 'Caracol' as Municipio union all
	select 'MS' as Estado, 'Cassilândia' as Municipio union all
	select 'MS' as Estado, 'Chapadão do Sul' as Municipio union all
	select 'MS' as Estado, 'Corguinho' as Municipio union all
	select 'MS' as Estado, 'Coronel Sapucaia' as Municipio union all
	select 'MS' as Estado, 'Corumbá' as Municipio union all
	select 'MS' as Estado, 'Costa Rica' as Municipio union all
	select 'MS' as Estado, 'Coxim' as Municipio union all
	select 'MS' as Estado, 'Deodápolis' as Municipio union all
	select 'MS' as Estado, 'Dois Irmãos do Buriti' as Municipio union all
	select 'MS' as Estado, 'Douradina' as Municipio union all
	select 'MS' as Estado, 'Dourados' as Municipio union all
	select 'MS' as Estado, 'Eldorado' as Municipio union all
	select 'MS' as Estado, 'Fátima do Sul' as Municipio union all
	select 'MS' as Estado, 'Figueirão' as Municipio union all
	select 'MS' as Estado, 'Glória de Dourados' as Municipio union all
	select 'MS' as Estado, 'Guia Lopes da Laguna' as Municipio union all
	select 'MS' as Estado, 'Iguatemi' as Municipio union all
	select 'MS' as Estado, 'Inocência' as Municipio union all
	select 'MS' as Estado, 'Itaporã' as Municipio union all
	select 'MS' as Estado, 'Itaquiraí' as Municipio union all
	select 'MS' as Estado, 'Ivinhema' as Municipio union all
	select 'MS' as Estado, 'Japorã' as Municipio union all
	select 'MS' as Estado, 'Jaraguari' as Municipio union all
	select 'MS' as Estado, 'Jardim' as Municipio union all
	select 'MS' as Estado, 'Jateí' as Municipio union all
	select 'MS' as Estado, 'Juti' as Municipio union all
	select 'MS' as Estado, 'Ladário' as Municipio union all
	select 'MS' as Estado, 'Laguna Carapã' as Municipio union all
	select 'MS' as Estado, 'Maracaju' as Municipio union all
	select 'MS' as Estado, 'Miranda' as Municipio union all
	select 'MS' as Estado, 'Mundo Novo' as Municipio union all
	select 'MS' as Estado, 'Naviraí' as Municipio union all
	select 'MS' as Estado, 'Nioaque' as Municipio union all
	select 'MS' as Estado, 'Nova Alvorada do Sul' as Municipio union all
	select 'MS' as Estado, 'Nova Andradina' as Municipio union all
	select 'MS' as Estado, 'Novo Horizonte do Sul' as Municipio union all
	select 'MS' as Estado, 'Paranaíba' as Municipio union all
	select 'MS' as Estado, 'Paranhos' as Municipio union all
	select 'MS' as Estado, 'Pedro Gomes' as Municipio union all
	select 'MS' as Estado, 'Ponta Porã' as Municipio union all
	select 'MS' as Estado, 'Porto Murtinho' as Municipio union all
	select 'MS' as Estado, 'Ribas do Rio Pardo' as Municipio union all
	select 'MS' as Estado, 'Rio Brilhante' as Municipio union all
	select 'MS' as Estado, 'Rio Negro' as Municipio union all
	select 'MS' as Estado, 'Rio Verde de Mato Grosso' as Municipio union all
	select 'MS' as Estado, 'Rochedo' as Municipio union all
	select 'MS' as Estado, 'Santa Rita do Pardo' as Municipio union all
	select 'MS' as Estado, 'São Gabriel do Oeste' as Municipio union all
	select 'MS' as Estado, 'Selvíria' as Municipio union all
	select 'MS' as Estado, 'Sete Quedas' as Municipio union all
	select 'MS' as Estado, 'Sidrolândia' as Municipio union all
	select 'MS' as Estado, 'Sonora' as Municipio union all
	select 'MS' as Estado, 'Tacuru' as Municipio union all
	select 'MS' as Estado, 'Taquarussu' as Municipio union all
	select 'MS' as Estado, 'Terenos' as Municipio union all
	select 'MS' as Estado, 'Três Lagoas' as Municipio union all
	select 'MS' as Estado, 'Vicentina' as Municipio union all
	select 'MT' as Estado, 'Acorizal' as Municipio union all
	select 'MT' as Estado, 'Água Boa' as Municipio union all
	select 'MT' as Estado, 'Alta Floresta' as Municipio union all
	select 'MT' as Estado, 'Alto Araguaia' as Municipio union all
	select 'MT' as Estado, 'Alto Boa Vista' as Municipio union all
	select 'MT' as Estado, 'Alto Garças' as Municipio union all
	select 'MT' as Estado, 'Alto Paraguai' as Municipio union all
	select 'MT' as Estado, 'Alto Taquari' as Municipio union all
	select 'MT' as Estado, 'Apiacás' as Municipio union all
	select 'MT' as Estado, 'Araguaiana' as Municipio union all
	select 'MT' as Estado, 'Araguainha' as Municipio union all
	select 'MT' as Estado, 'Araputanga' as Municipio union all
	select 'MT' as Estado, 'Arenápolis' as Municipio union all
	select 'MT' as Estado, 'Aripuanã' as Municipio union all
	select 'MT' as Estado, 'Barão de Melgaço' as Municipio union all
	select 'MT' as Estado, 'Barra do Bugres' as Municipio union all
	select 'MT' as Estado, 'Barra do Garças' as Municipio union all
	select 'MT' as Estado, 'Bom Jesus do Araguaia' as Municipio union all
	select 'MT' as Estado, 'Brasnorte' as Municipio union all
	select 'MT' as Estado, 'Cáceres' as Municipio union all
	select 'MT' as Estado, 'Campinápolis' as Municipio union all
	select 'MT' as Estado, 'Campo Novo do Parecis' as Municipio union all
	select 'MT' as Estado, 'Campo Verde' as Municipio union all
	select 'MT' as Estado, 'Campos de Júlio' as Municipio union all
	select 'MT' as Estado, 'Canabrava do Norte' as Municipio union all
	select 'MT' as Estado, 'Canarana' as Municipio union all
	select 'MT' as Estado, 'Carlinda' as Municipio union all
	select 'MT' as Estado, 'Castanheira' as Municipio union all
	select 'MT' as Estado, 'Chapada dos Guimarães' as Municipio union all
	select 'MT' as Estado, 'Cláudia' as Municipio union all
	select 'MT' as Estado, 'Cocalinho' as Municipio union all
	select 'MT' as Estado, 'Colíder' as Municipio union all
	select 'MT' as Estado, 'Colniza' as Municipio union all
	select 'MT' as Estado, 'Comodoro' as Municipio union all
	select 'MT' as Estado, 'Confresa' as Municipio union all
	select 'MT' as Estado, 'Conquista D''Oeste' as Municipio union all
	select 'MT' as Estado, 'Cotriguaçu' as Municipio union all
	select 'MT' as Estado, 'Cuiabá' as Municipio union all
	select 'MT' as Estado, 'Curvelândia' as Municipio union all
	select 'MT' as Estado, 'Denise' as Municipio union all
	select 'MT' as Estado, 'Diamantino' as Municipio union all
	select 'MT' as Estado, 'Dom Aquino' as Municipio union all
	select 'MT' as Estado, 'Feliz Natal' as Municipio union all
	select 'MT' as Estado, 'Figueirópolis D''Oeste' as Municipio union all
	select 'MT' as Estado, 'Gaúcha do Norte' as Municipio union all
	select 'MT' as Estado, 'General Carneiro' as Municipio union all
	select 'MT' as Estado, 'Glória D''Oeste' as Municipio union all
	select 'MT' as Estado, 'Guarantã do Norte' as Municipio union all
	select 'MT' as Estado, 'Guiratinga' as Municipio union all
	select 'MT' as Estado, 'Indiavaí' as Municipio union all
	select 'MT' as Estado, 'Ipiranga do Norte' as Municipio union all
	select 'MT' as Estado, 'Itanhangá' as Municipio union all
	select 'MT' as Estado, 'Itaúba' as Municipio union all
	select 'MT' as Estado, 'Itiquira' as Municipio union all
	select 'MT' as Estado, 'Jaciara' as Municipio union all
	select 'MT' as Estado, 'Jangada' as Municipio union all
	select 'MT' as Estado, 'Jauru' as Municipio union all
	select 'MT' as Estado, 'Juara' as Municipio union all
	select 'MT' as Estado, 'Juína' as Municipio union all
	select 'MT' as Estado, 'Juruena' as Municipio union all
	select 'MT' as Estado, 'Juscimeira' as Municipio union all
	select 'MT' as Estado, 'Lambari D''Oeste' as Municipio union all
	select 'MT' as Estado, 'Lucas do Rio Verde' as Municipio union all
	select 'MT' as Estado, 'Luciára' as Municipio union all
	select 'MT' as Estado, 'Marcelândia' as Municipio union all
	select 'MT' as Estado, 'Matupá' as Municipio union all
	select 'MT' as Estado, 'Mirassol d''Oeste' as Municipio union all
	select 'MT' as Estado, 'Nobres' as Municipio union all
	select 'MT' as Estado, 'Nortelândia' as Municipio union all
	select 'MT' as Estado, 'Nossa Senhora do Livramento' as Municipio union all
	select 'MT' as Estado, 'Nova Bandeirantes' as Municipio union all
	select 'MT' as Estado, 'Nova Brasilândia' as Municipio union all
	select 'MT' as Estado, 'Nova Canaã do Norte' as Municipio union all
	select 'MT' as Estado, 'Nova Guarita' as Municipio union all
	select 'MT' as Estado, 'Nova Lacerda' as Municipio union all
	select 'MT' as Estado, 'Nova Marilândia' as Municipio union all
	select 'MT' as Estado, 'Nova Maringá' as Municipio union all
	select 'MT' as Estado, 'Nova Monte Verde' as Municipio union all
	select 'MT' as Estado, 'Nova Mutum' as Municipio union all
	select 'MT' as Estado, 'Nova Nazaré' as Municipio union all
	select 'MT' as Estado, 'Nova Olímpia' as Municipio union all
	select 'MT' as Estado, 'Nova Santa Helena' as Municipio union all
	select 'MT' as Estado, 'Nova Ubiratã' as Municipio union all
	select 'MT' as Estado, 'Nova Xavantina' as Municipio union all
	select 'MT' as Estado, 'Novo Horizonte do Norte' as Municipio union all
	select 'MT' as Estado, 'Novo Mundo' as Municipio union all
	select 'MT' as Estado, 'Novo Santo Antônio' as Municipio union all
	select 'MT' as Estado, 'Novo São Joaquim' as Municipio union all
	select 'MT' as Estado, 'Paranaíta' as Municipio union all
	select 'MT' as Estado, 'Paranatinga' as Municipio union all
	select 'MT' as Estado, 'Pedra Preta' as Municipio union all
	select 'MT' as Estado, 'Peixoto de Azevedo' as Municipio union all
	select 'MT' as Estado, 'Planalto da Serra' as Municipio union all
	select 'MT' as Estado, 'Poconé' as Municipio union all
	select 'MT' as Estado, 'Pontal do Araguaia' as Municipio union all
	select 'MT' as Estado, 'Ponte Branca' as Municipio union all
	select 'MT' as Estado, 'Pontes e Lacerda' as Municipio union all
	select 'MT' as Estado, 'Porto Alegre do Norte' as Municipio union all
	select 'MT' as Estado, 'Porto dos Gaúchos' as Municipio union all
	select 'MT' as Estado, 'Porto Esperidião' as Municipio union all
	select 'MT' as Estado, 'Porto Estrela' as Municipio union all
	select 'MT' as Estado, 'Poxoréo' as Municipio union all
	select 'MT' as Estado, 'Primavera do Leste' as Municipio union all
	select 'MT' as Estado, 'Querência' as Municipio union all
	select 'MT' as Estado, 'Reserva do Cabaçal' as Municipio union all
	select 'MT' as Estado, 'Ribeirão Cascalheira' as Municipio union all
	select 'MT' as Estado, 'Ribeirãozinho' as Municipio union all
	select 'MT' as Estado, 'Rio Branco' as Municipio union all
	select 'MT' as Estado, 'Rondolândia' as Municipio union all
	select 'MT' as Estado, 'Rondonópolis' as Municipio union all
	select 'MT' as Estado, 'Rosário Oeste' as Municipio union all
	select 'MT' as Estado, 'Salto do Céu' as Municipio union all
	select 'MT' as Estado, 'Santa Carmem' as Municipio union all
	select 'MT' as Estado, 'Santa Cruz do Xingu' as Municipio union all
	select 'MT' as Estado, 'Santa Rita do Trivelato' as Municipio union all
	select 'MT' as Estado, 'Santa Terezinha' as Municipio union all
	select 'MT' as Estado, 'Santo Afonso' as Municipio union all
	select 'MT' as Estado, 'Santo Antônio do Leste' as Municipio union all
	select 'MT' as Estado, 'Santo Antônio do Leverger' as Municipio union all
	select 'MT' as Estado, 'São Félix do Araguaia' as Municipio union all
	select 'MT' as Estado, 'São José do Povo' as Municipio union all
	select 'MT' as Estado, 'São José do Rio Claro' as Municipio union all
	select 'MT' as Estado, 'São José do Xingu' as Municipio union all
	select 'MT' as Estado, 'São José dos Quatro Marcos' as Municipio union all
	select 'MT' as Estado, 'São Pedro da Cipa' as Municipio union all
	select 'MT' as Estado, 'Sapezal' as Municipio union all
	select 'MT' as Estado, 'Serra Nova Dourada' as Municipio union all
	select 'MT' as Estado, 'Sinop' as Municipio union all
	select 'MT' as Estado, 'Sorriso' as Municipio union all
	select 'MT' as Estado, 'Tabaporã' as Municipio union all
	select 'MT' as Estado, 'Tangará da Serra' as Municipio union all
	select 'MT' as Estado, 'Tapurah' as Municipio union all
	select 'MT' as Estado, 'Terra Nova do Norte' as Municipio union all
	select 'MT' as Estado, 'Tesouro' as Municipio union all
	select 'MT' as Estado, 'Torixoréu' as Municipio union all
	select 'MT' as Estado, 'União do Sul' as Municipio union all
	select 'MT' as Estado, 'Vale de São Domingos' as Municipio union all
	select 'MT' as Estado, 'Várzea Grande' as Municipio union all
	select 'MT' as Estado, 'Vera' as Municipio union all
	select 'MT' as Estado, 'Vila Bela da Santíssima Trindade' as Municipio union all
	select 'MT' as Estado, 'Vila Rica' as Municipio union all
	select 'GO' as Estado, 'Abadia de Goiás' as Municipio union all
	select 'GO' as Estado, 'Abadiânia' as Municipio union all
	select 'GO' as Estado, 'Acreúna' as Municipio union all
	select 'GO' as Estado, 'Adelândia' as Municipio union all
	select 'GO' as Estado, 'Água Fria de Goiás' as Municipio union all
	select 'GO' as Estado, 'Água Limpa' as Municipio union all
	select 'GO' as Estado, 'Águas Lindas de Goiás' as Municipio union all
	select 'GO' as Estado, 'Alexânia' as Municipio union all
	select 'GO' as Estado, 'Aloândia' as Municipio union all
	select 'GO' as Estado, 'Alto Horizonte' as Municipio union all
	select 'GO' as Estado, 'Alto Paraíso de Goiás' as Municipio union all
	select 'GO' as Estado, 'Alvorada do Norte' as Municipio union all
	select 'GO' as Estado, 'Amaralina' as Municipio union all
	select 'GO' as Estado, 'Americano do Brasil' as Municipio union all
	select 'GO' as Estado, 'Amorinópolis' as Municipio union all
	select 'GO' as Estado, 'Anápolis' as Municipio union all
	select 'GO' as Estado, 'Anhanguera' as Municipio union all
	select 'GO' as Estado, 'Anicuns' as Municipio union all
	select 'GO' as Estado, 'Aparecida de Goiânia' as Municipio union all
	select 'GO' as Estado, 'Aparecida do Rio Doce' as Municipio union all
	select 'GO' as Estado, 'Aporé' as Municipio union all
	select 'GO' as Estado, 'Araçu' as Municipio union all
	select 'GO' as Estado, 'Aragarças' as Municipio union all
	select 'GO' as Estado, 'Aragoiânia' as Municipio union all
	select 'GO' as Estado, 'Araguapaz' as Municipio union all
	select 'GO' as Estado, 'Arenópolis' as Municipio union all
	select 'GO' as Estado, 'Aruanã' as Municipio union all
	select 'GO' as Estado, 'Aurilândia' as Municipio union all
	select 'GO' as Estado, 'Avelinópolis' as Municipio union all
	select 'GO' as Estado, 'Baliza' as Municipio union all
	select 'GO' as Estado, 'Barro Alto' as Municipio union all
	select 'GO' as Estado, 'Bela Vista de Goiás' as Municipio union all
	select 'GO' as Estado, 'Bom Jardim de Goiás' as Municipio union all
	select 'GO' as Estado, 'Bom Jesus de Goiás' as Municipio union all
	select 'GO' as Estado, 'Bonfinópolis' as Municipio union all
	select 'GO' as Estado, 'Bonópolis' as Municipio union all
	select 'GO' as Estado, 'Brazabrantes' as Municipio union all
	select 'GO' as Estado, 'Britânia' as Municipio union all
	select 'GO' as Estado, 'Buriti Alegre' as Municipio union all
	select 'GO' as Estado, 'Buriti de Goiás' as Municipio union all
	select 'GO' as Estado, 'Buritinópolis' as Municipio union all
	select 'GO' as Estado, 'Cabeceiras' as Municipio union all
	select 'GO' as Estado, 'Cachoeira Alta' as Municipio union all
	select 'GO' as Estado, 'Cachoeira de Goiás' as Municipio union all
	select 'GO' as Estado, 'Cachoeira Dourada' as Municipio union all
	select 'GO' as Estado, 'Caçu' as Municipio union all
	select 'GO' as Estado, 'Caiapônia' as Municipio union all
	select 'GO' as Estado, 'Caldas Novas' as Municipio union all
	select 'GO' as Estado, 'Caldazinha' as Municipio union all
	select 'GO' as Estado, 'Campestre de Goiás' as Municipio union all
	select 'GO' as Estado, 'Campinaçu' as Municipio union all
	select 'GO' as Estado, 'Campinorte' as Municipio union all
	select 'GO' as Estado, 'Campo Alegre de Goiás' as Municipio union all
	select 'GO' as Estado, 'Campo Limpo de Goiás' as Municipio union all
	select 'GO' as Estado, 'Campos Belos' as Municipio union all
	select 'GO' as Estado, 'Campos Verdes' as Municipio union all
	select 'GO' as Estado, 'Carmo do Rio Verde' as Municipio union all
	select 'GO' as Estado, 'Castelândia' as Municipio union all
	select 'GO' as Estado, 'Catalão' as Municipio union all
	select 'GO' as Estado, 'Caturaí' as Municipio union all
	select 'GO' as Estado, 'Cavalcante' as Municipio union all
	select 'GO' as Estado, 'Ceres' as Municipio union all
	select 'GO' as Estado, 'Cezarina' as Municipio union all
	select 'GO' as Estado, 'Chapadão do Céu' as Municipio union all
	select 'GO' as Estado, 'Cidade Ocidental' as Municipio union all
	select 'GO' as Estado, 'Cocalzinho de Goiás' as Municipio union all
	select 'GO' as Estado, 'Colinas do Sul' as Municipio union all
	select 'GO' as Estado, 'Córrego do Ouro' as Municipio union all
	select 'GO' as Estado, 'Corumbá de Goiás' as Municipio union all
	select 'GO' as Estado, 'Corumbaíba' as Municipio union all
	select 'GO' as Estado, 'Cristalina' as Municipio union all
	select 'GO' as Estado, 'Cristianópolis' as Municipio union all
	select 'GO' as Estado, 'Crixás' as Municipio union all
	select 'GO' as Estado, 'Cromínia' as Municipio union all
	select 'GO' as Estado, 'Cumari' as Municipio union all
	select 'GO' as Estado, 'Damianópolis' as Municipio union all
	select 'GO' as Estado, 'Damolândia' as Municipio union all
	select 'GO' as Estado, 'Davinópolis' as Municipio union all
	select 'GO' as Estado, 'Diorama' as Municipio union all
	select 'GO' as Estado, 'Divinópolis de Goiás' as Municipio union all
	select 'GO' as Estado, 'Doverlândia' as Municipio union all
	select 'GO' as Estado, 'Edealina' as Municipio union all
	select 'GO' as Estado, 'Edéia' as Municipio union all
	select 'GO' as Estado, 'Estrela do Norte' as Municipio union all
	select 'GO' as Estado, 'Faina' as Municipio union all
	select 'GO' as Estado, 'Fazenda Nova' as Municipio union all
	select 'GO' as Estado, 'Firminópolis' as Municipio union all
	select 'GO' as Estado, 'Flores de Goiás' as Municipio union all
	select 'GO' as Estado, 'Formosa' as Municipio union all
	select 'GO' as Estado, 'Formoso' as Municipio union all
	select 'GO' as Estado, 'Gameleira de Goiás' as Municipio union all
	select 'GO' as Estado, 'Goianápolis' as Municipio union all
	select 'GO' as Estado, 'Goiandira' as Municipio union all
	select 'GO' as Estado, 'Goianésia' as Municipio union all
	select 'GO' as Estado, 'Goiânia' as Municipio union all
	select 'GO' as Estado, 'Goianira' as Municipio union all
	select 'GO' as Estado, 'Goiás' as Municipio union all
	select 'GO' as Estado, 'Goiatuba' as Municipio union all
	select 'GO' as Estado, 'Gouvelândia' as Municipio union all
	select 'GO' as Estado, 'Guapó' as Municipio union all
	select 'GO' as Estado, 'Guaraíta' as Municipio union all
	select 'GO' as Estado, 'Guarani de Goiás' as Municipio union all
	select 'GO' as Estado, 'Guarinos' as Municipio union all
	select 'GO' as Estado, 'Heitoraí' as Municipio union all
	select 'GO' as Estado, 'Hidrolândia' as Municipio union all
	select 'GO' as Estado, 'Hidrolina' as Municipio union all
	select 'GO' as Estado, 'Iaciara' as Municipio union all
	select 'GO' as Estado, 'Inaciolândia' as Municipio union all
	select 'GO' as Estado, 'Indiara' as Municipio union all
	select 'GO' as Estado, 'Inhumas' as Municipio union all
	select 'GO' as Estado, 'Ipameri' as Municipio union all
	select 'GO' as Estado, 'Ipiranga de Goiás' as Municipio union all
	select 'GO' as Estado, 'Iporá' as Municipio union all
	select 'GO' as Estado, 'Israelândia' as Municipio union all
	select 'GO' as Estado, 'Itaberaí' as Municipio union all
	select 'GO' as Estado, 'Itaguari' as Municipio union all
	select 'GO' as Estado, 'Itaguaru' as Municipio union all
	select 'GO' as Estado, 'Itajá' as Municipio union all
	select 'GO' as Estado, 'Itapaci' as Municipio union all
	select 'GO' as Estado, 'Itapirapuã' as Municipio union all
	select 'GO' as Estado, 'Itapuranga' as Municipio union all
	select 'GO' as Estado, 'Itarumã' as Municipio union all
	select 'GO' as Estado, 'Itauçu' as Municipio union all
	select 'GO' as Estado, 'Itumbiara' as Municipio union all
	select 'GO' as Estado, 'Ivolândia' as Municipio union all
	select 'GO' as Estado, 'Jandaia' as Municipio union all
	select 'GO' as Estado, 'Jaraguá' as Municipio union all
	select 'GO' as Estado, 'Jataí' as Municipio union all
	select 'GO' as Estado, 'Jaupaci' as Municipio union all
	select 'GO' as Estado, 'Jesúpolis' as Municipio union all
	select 'GO' as Estado, 'Joviânia' as Municipio union all
	select 'GO' as Estado, 'Jussara' as Municipio union all
	select 'GO' as Estado, 'Lagoa Santa' as Municipio union all
	select 'GO' as Estado, 'Leopoldo de Bulhões' as Municipio union all
	select 'GO' as Estado, 'Luziânia' as Municipio union all
	select 'GO' as Estado, 'Mairipotaba' as Municipio union all
	select 'GO' as Estado, 'Mambaí' as Municipio union all
	select 'GO' as Estado, 'Mara Rosa' as Municipio union all
	select 'GO' as Estado, 'Marzagão' as Municipio union all
	select 'GO' as Estado, 'Matrinchã' as Municipio union all
	select 'GO' as Estado, 'Maurilândia' as Municipio union all
	select 'GO' as Estado, 'Mimoso de Goiás' as Municipio union all
	select 'GO' as Estado, 'Minaçu' as Municipio union all
	select 'GO' as Estado, 'Mineiros' as Municipio union all
	select 'GO' as Estado, 'Moiporá' as Municipio union all
	select 'GO' as Estado, 'Monte Alegre de Goiás' as Municipio union all
	select 'GO' as Estado, 'Montes Claros de Goiás' as Municipio union all
	select 'GO' as Estado, 'Montividiu' as Municipio union all
	select 'GO' as Estado, 'Montividiu do Norte' as Municipio union all
	select 'GO' as Estado, 'Morrinhos' as Municipio union all
	select 'GO' as Estado, 'Morro Agudo de Goiás' as Municipio union all
	select 'GO' as Estado, 'Mossâmedes' as Municipio union all
	select 'GO' as Estado, 'Mozarlândia' as Municipio union all
	select 'GO' as Estado, 'Mundo Novo' as Municipio union all
	select 'GO' as Estado, 'Mutunópolis' as Municipio union all
	select 'GO' as Estado, 'Nazário' as Municipio union all
	select 'GO' as Estado, 'Nerópolis' as Municipio union all
	select 'GO' as Estado, 'Niquelândia' as Municipio union all
	select 'GO' as Estado, 'Nova América' as Municipio union all
	select 'GO' as Estado, 'Nova Aurora' as Municipio union all
	select 'GO' as Estado, 'Nova Crixás' as Municipio union all
	select 'GO' as Estado, 'Nova Glória' as Municipio union all
	select 'GO' as Estado, 'Nova Iguaçu de Goiás' as Municipio union all
	select 'GO' as Estado, 'Nova Roma' as Municipio union all
	select 'GO' as Estado, 'Nova Veneza' as Municipio union all
	select 'GO' as Estado, 'Novo Brasil' as Municipio union all
	select 'GO' as Estado, 'Novo Gama' as Municipio union all
	select 'GO' as Estado, 'Novo Planalto' as Municipio union all
	select 'GO' as Estado, 'Orizona' as Municipio union all
	select 'GO' as Estado, 'Ouro Verde de Goiás' as Municipio union all
	select 'GO' as Estado, 'Ouvidor' as Municipio union all
	select 'GO' as Estado, 'Padre Bernardo' as Municipio union all
	select 'GO' as Estado, 'Palestina de Goiás' as Municipio union all
	select 'GO' as Estado, 'Palmeiras de Goiás' as Municipio union all
	select 'GO' as Estado, 'Palmelo' as Municipio union all
	select 'GO' as Estado, 'Palminópolis' as Municipio union all
	select 'GO' as Estado, 'Panamá' as Municipio union all
	select 'GO' as Estado, 'Paranaiguara' as Municipio union all
	select 'GO' as Estado, 'Paraúna' as Municipio union all
	select 'GO' as Estado, 'Perolândia' as Municipio union all
	select 'GO' as Estado, 'Petrolina de Goiás' as Municipio union all
	select 'GO' as Estado, 'Pilar de Goiás' as Municipio union all
	select 'GO' as Estado, 'Piracanjuba' as Municipio union all
	select 'GO' as Estado, 'Piranhas' as Municipio union all
	select 'GO' as Estado, 'Pirenópolis' as Municipio union all
	select 'GO' as Estado, 'Pires do Rio' as Municipio union all
	select 'GO' as Estado, 'Planaltina' as Municipio union all
	select 'GO' as Estado, 'Pontalina' as Municipio union all
	select 'GO' as Estado, 'Porangatu' as Municipio union all
	select 'GO' as Estado, 'Porteirão' as Municipio union all
	select 'GO' as Estado, 'Portelândia' as Municipio union all
	select 'GO' as Estado, 'Posse' as Municipio union all
	select 'GO' as Estado, 'Professor Jamil' as Municipio union all
	select 'GO' as Estado, 'Quirinópolis' as Municipio union all
	select 'GO' as Estado, 'Rialma' as Municipio union all
	select 'GO' as Estado, 'Rianápolis' as Municipio union all
	select 'GO' as Estado, 'Rio Quente' as Municipio union all
	select 'GO' as Estado, 'Rio Verde' as Municipio union all
	select 'GO' as Estado, 'Rubiataba' as Municipio union all
	select 'GO' as Estado, 'Sanclerlândia' as Municipio union all
	select 'GO' as Estado, 'Santa Bárbara de Goiás' as Municipio union all
	select 'GO' as Estado, 'Santa Cruz de Goiás' as Municipio union all
	select 'GO' as Estado, 'Santa Fé de Goiás' as Municipio union all
	select 'GO' as Estado, 'Santa Helena de Goiás' as Municipio union all
	select 'GO' as Estado, 'Santa Isabel' as Municipio union all
	select 'GO' as Estado, 'Santa Rita do Araguaia' as Municipio union all
	select 'GO' as Estado, 'Santa Rita do Novo Destino' as Municipio union all
	select 'GO' as Estado, 'Santa Rosa de Goiás' as Municipio union all
	select 'GO' as Estado, 'Santa Tereza de Goiás' as Municipio union all
	select 'GO' as Estado, 'Santa Terezinha de Goiás' as Municipio union all
	select 'GO' as Estado, 'Santo Antônio da Barra' as Municipio union all
	select 'GO' as Estado, 'Santo Antônio de Goiás' as Municipio union all
	select 'GO' as Estado, 'Santo Antônio do Descoberto' as Municipio union all
	select 'GO' as Estado, 'São Domingos' as Municipio union all
	select 'GO' as Estado, 'São Francisco de Goiás' as Municipio union all
	select 'GO' as Estado, 'São João da Paraúna' as Municipio union all
	select 'GO' as Estado, 'São João d''Aliança' as Municipio union all
	select 'GO' as Estado, 'São Luís de Montes Belos' as Municipio union all
	select 'GO' as Estado, 'São Luíz do Norte' as Municipio union all
	select 'GO' as Estado, 'São Miguel do Araguaia' as Municipio union all
	select 'GO' as Estado, 'São Miguel do Passa Quatro' as Municipio union all
	select 'GO' as Estado, 'São Patrício' as Municipio union all
	select 'GO' as Estado, 'São Simão' as Municipio union all
	select 'GO' as Estado, 'Senador Canedo' as Municipio union all
	select 'GO' as Estado, 'Serranópolis' as Municipio union all
	select 'GO' as Estado, 'Silvânia' as Municipio union all
	select 'GO' as Estado, 'Simolândia' as Municipio union all
	select 'GO' as Estado, 'Sítio d''Abadia' as Municipio union all
	select 'GO' as Estado, 'Taquaral de Goiás' as Municipio union all
	select 'GO' as Estado, 'Teresina de Goiás' as Municipio union all
	select 'GO' as Estado, 'Terezópolis de Goiás' as Municipio union all
	select 'GO' as Estado, 'Três Ranchos' as Municipio union all
	select 'GO' as Estado, 'Trindade' as Municipio union all
	select 'GO' as Estado, 'Trombas' as Municipio union all
	select 'GO' as Estado, 'Turvânia' as Municipio union all
	select 'GO' as Estado, 'Turvelândia' as Municipio union all
	select 'GO' as Estado, 'Uirapuru' as Municipio union all
	select 'GO' as Estado, 'Uruaçu' as Municipio union all
	select 'GO' as Estado, 'Uruana' as Municipio union all
	select 'GO' as Estado, 'Urutaí' as Municipio union all
	select 'GO' as Estado, 'Valparaíso de Goiás' as Municipio union all
	select 'GO' as Estado, 'Varjão' as Municipio union all
	select 'GO' as Estado, 'Vianópolis' as Municipio union all
	select 'GO' as Estado, 'Vicentinópolis' as Municipio union all
	select 'GO' as Estado, 'Vila Boa' as Municipio union all
	select 'GO' as Estado, 'Vila Propício' as Municipio union all
	select 'DF' as Estado, 'Brasília' as Municipio 

) t



insert into Core_District (StateOrProvinceId, Name, Type)
select s.id, tmp.Municipio, 'Cidade'
from #tmpCidades as tmp
join Core_StateOrProvince as s
	on s.code = tmp.Estado
	and s.CountryId = 'BR'
left join Core_District as d
	on d.StateOrProvinceId = s.Id
	and d.name = tmp.Municipio
where d.id is null
