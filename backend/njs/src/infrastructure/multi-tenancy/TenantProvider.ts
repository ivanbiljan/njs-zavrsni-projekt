export class TenantProviderResult {
    private readonly _tenantId?: string;

    constructor(tenantId?: string) {
        this._tenantId = tenantId;
    }

    static Empty: TenantProviderResult = new TenantProviderResult(undefined);

    public get tenantId(): string | undefined {
        return this._tenantId;
    }
}

export interface TenantProvider {
    tenant: () => TenantProviderResult | undefined;
}