import { Module } from "@nestjs/common";
import { SequelizeModule } from "@nestjs/sequelize";
import User from "../../infrastructure/data/User";

@Module({
    imports: [SequelizeModule.forFeature([User])],
    controllers: [],
    providers: [],
})
export class AuthenticationModule {}