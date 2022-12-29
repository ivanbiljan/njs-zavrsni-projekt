import { Sequelize } from "sequelize-typescript";
export declare const sequelizeProviders: {
    provide: string;
    useFactory: () => Promise<Sequelize>;
}[];
