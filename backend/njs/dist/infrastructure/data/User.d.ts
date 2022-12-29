import AuditableEntityBase from "./AuditableEntityBase";
export default class User extends AuditableEntityBase {
    firstName: string;
    lastName: string;
    email: string;
    hashedPassword: string;
}
