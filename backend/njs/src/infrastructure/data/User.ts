import { Column, Model, Table } from "sequelize-typescript";
import AuditableEntityBase from "./AuditableEntityBase";

@Table
export default class User extends AuditableEntityBase {
    @Column
    firstName: string;

    @Column
    lastName: string;

    @Column
    email: string;

    @Column
    hashedPassword: string;
}
