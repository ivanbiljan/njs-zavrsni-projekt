import { Column } from "sequelize-typescript";
import EntityBase from "./EntityBase";

export default class AuditableEntityBase extends EntityBase {
    @Column
    createdAtUc: Date;

    @Column
    modifiedAtUtc?: Date;

    @Column
    archivedAtUtc?: Date;
}