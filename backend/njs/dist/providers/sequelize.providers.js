"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.sequelizeProviders = void 0;
const sequelize_typescript_1 = require("sequelize-typescript");
exports.sequelizeProviders = [
    {
        provide: "SEQUELIZE",
        useFactory: async () => {
            const sequelize = new sequelize_typescript_1.Sequelize({
                dialect: "mysql",
                host: "localhost",
                port: 3306,
                username: "root",
                password: "password",
                database: "njs"
            });
            sequelize.addModels(["./../core/infrastructure/data/"]);
            await sequelize.sync();
            return sequelize;
        }
    }
];
//# sourceMappingURL=sequelize.providers.js.map