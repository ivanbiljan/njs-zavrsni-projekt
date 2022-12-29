import EntityBase from "./EntityBase";
export default class AuditableEntityBase extends EntityBase {
    createdAtUc: Date;
    modifiedAtUtc?: Date;
    archivedAtUtc?: Date;
}
