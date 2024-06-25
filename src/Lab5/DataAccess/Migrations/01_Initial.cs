#pragma warning disable SA1649
using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'admin',
            'user' 
        );
        
        create type operation_type as enum
        (
            'withdrawal',
            'replenishment'
        );
        
        create table users
        (
            user_id bigint primary key generated always as identity ,
            username text not null ,
            user_role user_role not null,
            password text not null 
        );
        
        create table bank_accounts
        (
            account_id bigint primary key generated always as identity ,
            user_id bigint not null references users(user_id),
            balance money not null 
        );
        
        create table operations
        (
            operation_id bigint primary key generated always as identity ,
            account_id bigint not null references bank_accounts(account_id) ,
            operation_type operation_type not null ,
            amount money not null
        );
        
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>

        """
            drop table users cascade ;
            drop table bank_accounts cascade ;
            drop table operations cascade ;

            drop type user_role;
            drop type operation_type;
        """;
}