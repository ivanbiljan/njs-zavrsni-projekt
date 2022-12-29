import { Column } from "sequelize-typescript";

export default class EntityBase {
    @Column
    id: number;
}

