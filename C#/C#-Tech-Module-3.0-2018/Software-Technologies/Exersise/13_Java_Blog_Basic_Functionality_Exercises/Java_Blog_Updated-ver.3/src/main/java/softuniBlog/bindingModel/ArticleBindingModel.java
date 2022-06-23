package softuniBlog.bindingModel;

import javax.validation.constraints.NotNull;
import java.time.LocalDateTime;

public class ArticleBindingModel {

    @NotNull
    private String title;

    @NotNull
    private String picture;

    @NotNull
    private String content;

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }


    public String getPicture() {
        return picture;
    }

    public void setPicture(String picture) {
        this.picture = picture;
    }
}
