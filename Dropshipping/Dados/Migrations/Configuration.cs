using System.Collections.Generic;
using System.Linq;
using Entidades;

namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

		// SEED para aplicar carga inicial a base de dados
        protected override void Seed(LojaDbContext context)
		{
			CadastrarProdutos(context);
			CadastrarFornecedor(context);
		}

	    private void CadastrarFornecedor(LojaDbContext context)
		{
			context.FornecedorSet.AddOrUpdate(new Fornecedor
			{
				Codigo = 1,
				Nome = "B2D Fornecedora",
				UsuarioApi = "chefsuser",
				SenhaApi = "chefspassword",
				ProdutoSet = ProdutosFornecedor(),
				Visivel = true
			});
		}

		private static List<PrecoProdutoFornecedor> ProdutosFornecedor()
		{
			return new List<PrecoProdutoFornecedor>
			{
				new PrecoProdutoFornecedor {CodigoFornecedor = 1, CodigoProduto = 1, Quantidade = 100, Preco = 2245.00m},
				new PrecoProdutoFornecedor {CodigoFornecedor = 1, CodigoProduto = 2, Quantidade = 100, Preco = 9999.00m},
				new PrecoProdutoFornecedor {CodigoFornecedor = 1, CodigoProduto = 3, Quantidade = 100, Preco = 2889.00m},
				new PrecoProdutoFornecedor {CodigoFornecedor = 1, CodigoProduto = 4, Quantidade = 100, Preco = 1139.00m},
				new PrecoProdutoFornecedor {CodigoFornecedor = 1, CodigoProduto = 5, Quantidade = 100, Preco = 349.00m},
				new PrecoProdutoFornecedor {CodigoFornecedor = 1, CodigoProduto = 6, Quantidade = 100, Preco = 799.00m},
				new PrecoProdutoFornecedor {CodigoFornecedor = 1, CodigoProduto = 7, Quantidade = 100, Preco = 1399.00m},
				new PrecoProdutoFornecedor {CodigoFornecedor = 1, CodigoProduto = 8, Quantidade = 100, Preco = 399.00m}
			};
		}

		private static void CadastrarProdutos(LojaDbContext context)
		{
			context.ProdutoSet.AddOrUpdate(x => x.Codigo, Produto1());
			context.ProdutoSet.AddOrUpdate(x => x.Codigo, Produto2());
			context.ProdutoSet.AddOrUpdate(x => x.Codigo, Produto3());
			context.ProdutoSet.AddOrUpdate(x => x.Codigo, Produto4());
			context.ProdutoSet.AddOrUpdate(x => x.Codigo, Produto5());
			context.ProdutoSet.AddOrUpdate(x => x.Codigo, Produto6());
			context.ProdutoSet.AddOrUpdate(x => x.Codigo, Produto7());
			context.ProdutoSet.AddOrUpdate(x => x.Codigo, Produto8());
		}

		private static Produto Produto8()
	    {
			return ProdutoFactory(8,
				"Mini processador em a�o escovado Cuisinart - dlc1ss - 127V",
				"Perfeito ajudante na cozinha. Produzido pela Americana Cuisinart em a�o escovado de alta qualidade, compacto e port�til mini processador com diversas fun��es program�veis. Excelente para picar, moer ou liquidificar com grande desempenho, o Mini Processador Cuisinart facilita o preparo de diversas receitas. Ainda conta com pot�ncia de 180W. Copo em Lexan com capacidade de 600ml.",
				19, 20, 21, 22
			);
		}

	    private static Produto Produto7()
	    {
			return ProdutoFactory(7,
				"Bloco para facas com 14 pe�as em a�o inox graphix Cuisinart",
				"Este bloco conta com as principais e mais utilizadas facas de cozinha. Al�m de altamente funcional, possui design moderno e elegante deixar� o ambiente muito mais charmoso e completo. Suas facas s�o produzidas em a�o inox AISI420 que garante tempo de vida �til prolongado, enquanto os cabos mais largos possuem o peso ideal para um manuseio firme e seguro. Ainda conta com bloco em madeira emborrachada que garante estabilidade na bancada ou pia. Fabricado pela Americana Cuisinart, marca com mais de 35 anos de experi�ncia na fabrica��o de produtos com alta tecnologia e conceito, aliando design e funcionalidade a fim de otimizar o uso de cada pe�a.",
				17, 18
			);
		}

	    private static Produto Produto6()
	    {
			return ProdutoFactory(6,
				"Conjunto de 4 panelas em a�o inox classic Cuisinart",
				"Fabricado pela Americana Cuisinart, conjunto de panelas em a�o inox com excelente revestimento antiaderente. Exclusivo sistema Cool Grip e tampas que proporcionam veda��o perfeita. Parte da linha Classic, este pr�tico conjunto auxilia no preparo de diversos pratos. Todas as panelas s�o produzidas com fundo triplo que aquecem rapidamente e distribui o calor por toda extremidade. O sistema Cool Grip evita que as al�as esquentem durante o cozimento, enquanto a tampa veda com perfei��o, evitando a perda dos nutrientes do alimento. O conjunto de panelas � composto por: 1 panela de 16cm com capacidade de 1,4 litros, 1 panela de 20cm com capacidade de 2,9 litros, 1 ca�arola de 24cm com capacidade de 7,6 litros e 1 frigideira de 24cm.",
				16
			);
		}

	    private static Produto Produto5()
	    {
			return ProdutoFactory(5,
				"Hand mixer em a�o escovado com 2 velocidades - csb-79br - 220V",
				"Este pr�tico e compacto Hand Mixer al�m da fun��o mixer, que prepara sucos, molhos e batidas em poucos segundos, tamb�m conta com outros dois acess�rios; o batedor para massas leves e o mini picador com l�mina em a�o inox para frutas e verduras. Com pot�ncia de 130W seu funcionamento pode ocorrer em 2 velocidades para oferecer muito mais precis�o em cada tipo de receita. Produzido pela Americana Cuisinart, a mais de 35 anos oferecendo produtos funcionais, testados e aprovados por grandes chefes de todo o mundo, a fim de otimizar o uso de cada pe�a. Composi��o: 1 Base do Hand Mixer; 1 Haste remov�vel; 1 Copo medidor com capacidade de 500ml; 1 Batedor; 1 Tigela do triturador com uma h�lice; 1 Manual de instru��es;1 Certificado de garantia. Medidas aproximadas do produto: 31cm de altura; 26cm de largura; 13,5cm de profundidade.",
				13, 14, 15
			);
		}

	    private static Produto Produto4()
	    {
			return ProdutoFactory(4,
				"Forno El�trico de Embutir Electrolux com 59 Litros Preto (OE60M)",
				"Compacto por fora e espa�oso por dentro. O Forno de embutir com 59 Litros de capacidade e fun��es de assados preto (OE60M) ajuda a economizar espa�o e garante refei��es perfeitas e saborosas para a fam�lia e convidados. Prepare bolos, massas ou carnes e deixe - os quentinhos para receber uma visita de �ltima hora com a Fun��o manter aquecido.Esqueceu do forno enquanto recebia seus convidados? N�o se preocupe!O Timer com Desligamento desliga o forno assim que o tempo definido no painel chega ao fim.  At� na hora de limpar n�o tem segredo. O esmalte Simple + clean ajuda a remover manchas e part�culas de gorduras que ficam acumuladas no interior do forno, deixando - o sempre limpo e conservado. Mais praticidade para sua cozinha estar sempre impec�vel e brilhante!",
				10, 11, 12
			);
		}

	    private static Produto Produto3()
	    {
			return ProdutoFactory(3,
				"Coifa de Ilha 90 cm Electrolux Blue Touch (90CIT)",
				"Voc� n�o precisa mais se isolar quando for cozinhar um Steak Grill� Sauce B�rnaise para os amigos. Com seu design arrojado, a coifa 90CIT transformar a cozinha em um local de confraterniza��o.",
				7, 8, 9
			);
		}

	    private static Produto Produto2()
	    {
		    return ProdutoFactory(2,
			    "Refrigerador French Door Icon Inox (FDI90)",
			    "Para fam�lias que t�m muito estilo para armazenar. 634 litros de capacidade para guardar todo o charme que voc� busca em um refrigerador. Com um alto padr�o de design e acabamento, o produto � ideal para cozinhas premium. A tecnologia touch control garante maior facilidade na hora da limpeza, economizando seu tempo na organiza��o da sua casa. Al�m de outras fun��es que facilitam a sua rotina na cozinha, o Refrigerador French Door FDI90 Inox vem com organizadores internos no freezer que permitem armazenar seus alimentos de maneira pr�tica: bandeja deslizante, divis�rias e compartimento para armazenar gelo. Tudo fica mais f�cil quando seu refrigerador � muito mais do que uma geladeira.",
				4, 5, 6
		    );
	    }

	    private static Produto Produto1()
	    {
			return ProdutoFactory(1,
				"Cooktop de Indu��o 4 Queimadores (IC60)",
				"O Cooktop IC60 � perfeito para quem busca qualidade e sofistica��o na hora de cozinhar. Possui 9 n�veis de pot�ncia, painel touch, timer e a exclusiva fun��o Turbo Pot�ncia, que libera at� 160% mais potencia por at� 10 minutos. Possui ainda uma trava de painel para evitar que a programa��o seja alterada e a mesa Vitrocer�mica deixa a limpeza mais f�cil.",
				1, 2, 3
			);
	    }

	    private static Produto ProdutoFactory(int codigo, string nome, string descricao, params int[] ids)
		{
			return new Produto()
			{
				Codigo = codigo,
				Descricao = descricao,
				Nome = nome,
				Visivel = true,
				DataCriacao = DateTime.Now.AddDays(-codigo),
				UrlImagemDetalheSet = ImagemSetFactory(ids)
			};
		}

		private static List<UrlImagem> ImagemSetFactory(IEnumerable<int> ids)
		{
			return ids.Select(t => new UrlImagem($"Content/Produtos/{t}.png")).ToList();
		}
	}
}