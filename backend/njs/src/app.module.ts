import { Module } from '@nestjs/common';
import { SequelizeModule } from "@nestjs/sequelize";

@Module({
  imports: [
      SequelizeModule.forRoot({
          dialect: 'mysql',
          host: 'localhost',
          port: 3306,
          username: 'root',
          password: 'password',
          database: 'nest',
          autoLoadModels: true,
          synchronize: true
      })
  ],
  controllers: [],
  providers: [],
})
export class AppModule {}
