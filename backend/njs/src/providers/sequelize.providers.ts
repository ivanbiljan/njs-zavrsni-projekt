import { Sequelize } from "sequelize-typescript";

export const sequelizeProviders = [
    {
        provide: "SEQUELIZE",
        useFactory: async () => {
            const sequelize = new Sequelize({
                dialect: "mysql",
                host: "localhost",
                port: 3306,
                username: "root",
                password: "password",
                database: "njs"
            });

            sequelize.addModels(["/src/core/infrastructure/data"]);
            await sequelize.sync();

            return sequelize;
        }
    }
];