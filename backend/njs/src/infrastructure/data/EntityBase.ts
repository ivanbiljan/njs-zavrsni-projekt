import { Column, Model } from "sequelize-typescript";

export default class EntityBase extends Model {
    @Column
    id: number;
}

