import React from "react";

interface FooterLinkProps {
    text: string;
    url: string;
}

const FooterLink = (props: FooterLinkProps) => {
    const { text, url } = props;

    return (
        <a className={"no-underline text-[var(--text-secondary-dark)]"} href={url}>{text}</a>
    );
};

interface FooterSectionProps {
    title: string;
    children: React.ReactNode;
}

const FooterSection = (props: FooterSectionProps) => {
    const { title, children } = props;

    return (
        <div className={"flex flex-col gap-4"}>
            <h6 className={"text-[var(--brand-primary)]"}>{title}</h6>
            {children}
        </div>
    );
};

const Footer = () => {
    return (
        <footer
            className={"absolute bottom-0 left-0 right-0 w-100 xl:max-h-[512px] bg-black px-[20px] py-[80px] lg:px-[135px] lg:py-[100px]"}>
            <div className={"flex flex-col justify-evenly items-start gap-16"}>
                <div className={"w-[100%] flex flex-wrap flex-row justify-between items-baseline gap-4"}>
                    <div className={"flex flex-col gap-4"}>
                        <h1 className={"text-white"}>YAY!</h1>
                    </div>
                    <div className={"flex flex-row flex-wrap gap-[2rem] md:gap-[5rem] [&>*]:w-[10.625rem]"}>
                        <FooterSection title={"Shop"}>
                            <FooterLink text={"Home"} url={"/"} />
                            <FooterLink text={"Shop all gift cards"} url={"/"} />
                        </FooterSection>
                        <FooterSection title={"Products"}>
                            <FooterLink text={"YAY For Business"} url={"/"} />
                            <FooterLink text={"YAY For Merchants"} url={"/"} />
                            <FooterLink text={"YAY Franchise"} url={"/"} />
                        </FooterSection>
                        <FooterSection title={"Resources"}>
                            <FooterLink text={"Get the app"} url={"/"} />
                        </FooterSection>
                        <FooterSection title={"YAY"}>
                            <FooterLink text={"About us"} url={"/"} />
                            <FooterLink text={"Contact"} url={"/"} />
                        </FooterSection>
                    </div>
                </div>
                <hr className={"w-[100%] border-opacity-10"} />
                <div className={"flex flex-row flex-wrap justify-between items-center"}>
                    <div className={"flex flex-row gap-8"}>
                        <FooterLink text={"Terms of Use"} url={"/"}/>
                        <FooterLink text={"Privacy"} url={"/"}/>
                    </div>
                </div>
            </div>
        </footer>
    );
};

export default Footer;