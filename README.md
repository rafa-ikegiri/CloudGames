A FIAP Cloud Games (FCG) será uma plataforma de venda de jogos digitais e gestão de servidores para partidas online.

MVP de uma API REST em .NET 8 para gerenciar usuários e seus jogos adquiridos

Foi utilizado Entity Framework e banco SQL Server, implementado Middleware para tratamento de erros.
Foram criados 2 niveis de acesso: Usuário e Admin
Para validar a autorização é feita via JWT para geração do token e validação de perfil.
Usuário apenas lista os jogos.
Admin consegue fazer tudo, cadastrar, consultar, atualizar e deletetar jogos e usuários.

