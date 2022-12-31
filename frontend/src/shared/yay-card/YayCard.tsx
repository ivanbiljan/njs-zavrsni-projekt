import "./YayCard.scss";

export interface YayCardProps {
    logo?: JSX.Element;
    title: string;
    description: string;
}

export const YayCard = (props: YayCardProps) => {
    const {logo, title, description} = props;

    return (
        <div className={"card"}>
            <div className={"logo"}>
            {
                logo ? logo : <></>
            }
            </div>

            <h5>{title}</h5>
            <p className={"small"}>{description}</p>
        </div>
    );
}